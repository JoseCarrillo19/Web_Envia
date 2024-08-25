using NuGet.Protocol.Core.Types;
using Web_Envia.Application.IServices;
using Web_Envia.Domain.IRepository;
using Web_Envia.Domain.Models;
using Web_Envia.Domain.Models.Enum;

namespace Web_Envia.Application.Services
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
            guia.NumeroGuia = GenerarNumeroGuiaUnico();
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
            var request = _guiaRepository.GetById(id);
            return request;
        }

        public string GenerarNumeroGuiaUnico()
        {
            string numeroGuia;
            do
            {
                numeroGuia = GenerarNumeroGuiaAleatorio();
            } while (_guiaRepository.ExisteNumeroGuia(numeroGuia));

            return numeroGuia;
        }

        private string GenerarNumeroGuiaAleatorio()
        {
            var random = new Random();
            var numeroGuia = string.Concat(Enumerable.Range(0, 12).Select(_ => random.Next(0, 10).ToString()));
            return numeroGuia;
        }

    }
}
