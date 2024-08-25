using Web_Envia.Domain.Models;
using Web_Envia.Domain.Models.Enum;

namespace Web_Envia.Domain.IRepository
{
    public interface IGuidesRegistrationRepository
    {
        void Add(Guides guia);
        Guides GetById(int id);
        IEnumerable<Guides> GetByEstadoAndDestinatario(Estados estado, string destinatario);
        void Update(Guides guia);
        IEnumerable<Guides> GetAll();
        Guides GetByNumeroGuia(string numeroGuia);
        bool ExisteNumeroGuia(string numeroGuia);
    }
}
