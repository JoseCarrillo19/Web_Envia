using Web_Envia.Domain.Models;
using Web_Envia.Domain.Models.Enum;

namespace Web_Envia.Application.IServices
{
    public interface IGuidesRegistrationServices
    {
        void RegistrarGuia(Guides guia);
        IEnumerable<Guides> BuscarGuias(Estados estado, string destinatario);
        double FinalizarGuia(int id);
        Guides BuscarPorNumeroGuia(string numeroGuia);
        Guides ObtenerGuiaPorId(int id);
    }
}
