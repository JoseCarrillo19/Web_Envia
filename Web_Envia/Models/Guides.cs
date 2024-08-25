using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using Web_Envia.Models.Enum;

namespace Web_Envia.Models
{
    public class Guides : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string? NumeroGuia { get; set; }
        public string? Destinatario { get; set; }
        public string? Direccion { get; set; }
        public TipoServicio TipoServicio { get; set; }
        public double Peso { get; set; }
        public double Cantidad { get; set; }
        public bool EsInternacional { get; set; }
        public Estados EstadoGuides { get; set; }
        public double ValorServicio { get; set; }

        public double CalcularValor()
        {
            const double valorBase = 5000;
            double valor = valorBase;

            switch (TipoServicio)
            {
                case TipoServicio.Sobre:
                    valor += 10000;
                    break;
                case TipoServicio.Paquete:
                    valor += Peso * valorBase;
                    break;
                case TipoServicio.Caja:
                    valor += Peso * valorBase + 25000;
                    break;
            }

            if (EsInternacional)
            {
                valor *= 1.25;
            }

            return valor;
        }
    }
}
