using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace IFMGBot
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Task.Run(() => new DiscordBot());

            Console.ReadLine();
        }
        
    }
}
