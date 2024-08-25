using Web_Envia.Models;
using Web_Envia.Models.Enum;

namespace Web_Envia.Infrastructure.Repository.IRepository
{
    public interface IGuidesRegistrationRepository
    {
        void Add(Guides guia);
        Guides GetById(int id);
        IEnumerable<Guides> GetByEstadoAndDestinatario(Estados estado, string destinatario);
        void Update(Guides guia);
        IEnumerable<Guides> GetAll();
        Guides GetByNumeroGuia(string numeroGuia);
    }
}
