using Discord.Commands;
using IFMGBot.Common;
using IFMGBot.Domain.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IFMGBot.Commands
{
    public class Commands : ModuleBase<IFSocketCommandContext>
    {
        [Command("ping")]
        public async Task Ping() {
            await ReplyAsync(":)! ..");
        }

        [Command("email")]
        public async Task Email([Remainder] string profName)
        {
            throw new NotImplementedException();
        }

        [Command("contato")]
        public async Task Contato([Remainder] string remaining)
        {
            var profs = ContactInfoDomainService.GetInstance().BuscarTodos().Select(x => $"Professor {x.Descricao}, Email: {x.Email}" );
            await ReplyAsync(string.Join(", ", profs));
            throw new NotImplementedException();
        }
    }
}
