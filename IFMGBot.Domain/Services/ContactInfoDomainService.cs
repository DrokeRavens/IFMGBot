using IFMGBot.Domain.VO;
using IFMGBot.EF;
using System.Collections.Generic;
using System.Linq;

namespace IFMGBot.Domain.Services
{
    public sealed class ContactInfoDomainService
    {
        private readonly static ContactInfoDomainService _contactInfoService = new ContactInfoDomainService();
        private ContactInfoDomainService() { }
        public static ContactInfoDomainService GetInstance()
        {
            return _contactInfoService;
        }
        private readonly IFMGDbContext _context = new IFMGDbContext();
        public List<ContactInfoProjectionVO> BuscarTodos() {
            var professoresDB = _context.Contatos.Select(x => new ContactInfoProjectionVO {
                Descricao = x.Descricao,
                Email = x.Email,
                Telefone = x.Telefone
            }).ToList();

            return professoresDB;
        }
    }
}
