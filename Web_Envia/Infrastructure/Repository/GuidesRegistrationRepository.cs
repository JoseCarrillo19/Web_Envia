using Microsoft.EntityFrameworkCore;
using Web_Envia.Domain.IRepository;
using Web_Envia.Domain.Models;
using Web_Envia.Domain.Models.Enum;
using Web_Envia.Infrastructure.Data;

namespace Web_Envia.Infrastructure.Repository
{
    public class GuidesRegistrationRepository : IGuidesRegistrationRepository
    {
        private readonly ApplicationDbContext _context;

        public GuidesRegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Guides guia)
        {
            _context.Guias.Add(guia);
            _context.SaveChanges();
        }

        public Guides GetById(int id)
        {
            return _context.Guias
                    .Include(g => g.Remitente) 
                    .FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Guides> GetByEstadoAndDestinatario(Estados estado, string destinatario)
        {
            return _context.Guias
                           .Where(g => g.EstadoGuides == estado && g.Destinatario.Contains(destinatario))
                           .ToList();
        }

        public void Update(Guides guia)
        {
            _context.Guias.Update(guia);
            _context.SaveChanges();
        }

        public IEnumerable<Guides> GetAll()
        {
            return _context.Guias.ToList();
        }

        public Guides GetByNumeroGuia(string numeroGuia)
        {
            return _context.Guias.FirstOrDefault(g => g.NumeroGuia == numeroGuia);
        }
        public bool ExisteNumeroGuia(string numeroGuia)
        {
            return _context.Guias.Any(g => g.NumeroGuia == numeroGuia);
        }
    }
}
