using NuGet.Protocol.Core.Types;
using System;
using Web_Envia.Infrastructure.Repository.IRepository;
using Web_Envia.Models;
using Web_Envia.Models.Enum;
using Web_Envia.Services.IServices;

namespace Web_Envia.Services
{
    public class GuidesRegistrationServices : IGuidesRegistrationServices
    {
        private readonly IGuidesRegistrationRepository _guiaRepository;

        public GuidesRegistrationServices(IGuidesRegistrationRepository guiaRepository)
        {
            _guiaRepository = guiaRepository;
        }

        public void RegistrarGuia(Guides guia)
        {
            guia.Status = "CREATE";
            guia.CreatedBy = "ADMIN";
            guia.CreatedMachine = "1.1.1";
            guia.CreationDate = DateTime.Now;
            guia.ValorServicio = guia.CalcularValor();
            guia.EstadoGuides = Estados.DESPACHO;
            _guiaRepository.Add(guia);
        }

        public IEnumerable<Guides> BuscarGuias(Estados estado, string destinatario)
        {
            var query = _guiaRepository.GetAll();

            if (estado > 0)
            {
                query = query.Where(g => g.EstadoGuides == estado);
            }

            if (!string.IsNullOrEmpty(destinatario))
            {
                query = query.Where(g => g.Destinatario.Contains(destinatario));
            }

            return query.ToList();
        }


        public double FinalizarGuia(int id)
        {
            var guia = _guiaRepository.GetById(id);
            if (guia == null)
            {
                throw new Exception("Guía no encontrada.");
            }

            guia.EstadoGuides = Estados.FINALIZADA;

            double valorServicio = guia.CalcularValor();
            _guiaRepository.Update(guia);

            return valorServicio;
        }

        public Guides BuscarPorNumeroGuia(string numeroGuia)
        {
            return _guiaRepository.GetByNumeroGuia(numeroGuia);
        }

        public Guides ObtenerGuiaPorId(int id)
        {
            return _guiaRepository.GetById(id);
        }
    }
}
