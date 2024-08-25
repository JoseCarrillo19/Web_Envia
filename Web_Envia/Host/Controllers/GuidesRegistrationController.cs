using Microsoft.AspNetCore.Mvc;
using Web_Envia.Application.IServices;
using Web_Envia.Domain.Models;
using Web_Envia.Domain.Models.Enum;

namespace Web_Envia.Host.Controllers
{
    public class GuidesRegistrationController : Controller
    {
        private readonly IGuidesRegistrationServices _guiaService;

        public GuidesRegistrationController(IGuidesRegistrationServices guiaService)
        {
            _guiaService = guiaService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Guides guia)
        {
            if (ModelState.IsValid)
            {
                _guiaService.RegistrarGuia(guia);
                return RedirectToAction(nameof(CreateResult), new { numeroGuia = guia.NumeroGuia });
            }
            return View(guia);
        }

        [HttpGet]
        public IActionResult CreateResult(string numeroGuia)
        {
            ViewBag.NumeroGuia = numeroGuia;
            return View();
        }

        public IActionResult Search(Estados estado, string destinatario)
        {
            var guias = _guiaService.BuscarGuias(estado, destinatario);
            return View(guias);
        }

        [HttpGet]
        public IActionResult Finalizar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Finalizar(string numeroGuia)
        {
            if (string.IsNullOrEmpty(numeroGuia))
            {
                ModelState.AddModelError("", "Debe ingresar un número de guía.");
                return View();
            }

            var guia = _guiaService.BuscarPorNumeroGuia(numeroGuia);
            if (guia == null)
            {
                ModelState.AddModelError("", "No se encontró una guía con ese número.");
                return View();
            }

            return View("ConfirmarFinalizacion", guia);
        }

        [HttpPost]
        public IActionResult ConfirmarFinalizacion(int id)
        {
            var valorServicio = _guiaService.FinalizarGuia(id);
            if (valorServicio > 0)
            {
                ViewBag.ValorServicio = valorServicio;
                var guia = _guiaService.ObtenerGuiaPorId(id);
                return View("FinalizarResultado", guia);
            }
            return NotFound();
        }

        public IActionResult Detalle(int id)
        {
            var guia = _guiaService.ObtenerGuiaPorId(id);
            if (guia == null)
            {
                return NotFound();
            }

            return View(guia);
        }
    }
}
