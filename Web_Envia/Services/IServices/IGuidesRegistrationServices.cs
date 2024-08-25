using Web_Envia.Models;
using Web_Envia.Models.Enum;

namespace Web_Envia.Services.IServices
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
