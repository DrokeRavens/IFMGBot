using Discord.Commands;
using Discord.WebSocket;
using IFMGBot.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFMGBot.Common
{
    public class IFSocketCommandContext : SocketCommandContext
    {
        
        public IFSocketCommandContext(DiscordSocketClient client, SocketUserMessage msg) : base(client, msg)
        {
        }


    }
}
