using Discord;
using Discord.Commands;
using Discord.WebSocket;
using IFMGBot.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
namespace IFMGBot
{
    public class DiscordBot
    {
        private readonly string tokenApi = "Nzg5ODA2ODg4Nzc0NTMzMTMw.X93a_A.3FwswJnfAX-Xlo5bKQK-7Xu-_lU";
        private DiscordSocketClient _client;
        private IServiceProvider _services;
        private CommandService _commands;
        public DiscordBot() {
            Task.Run(() => RunBotAsync());
        }
        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            _client.Log += Log;
            await RegisterCommandAsync();
            await _client.LoginAsync(Discord.TokenType.Bot, tokenApi);
            await _client.StartAsync();
            await _client.SetStatusAsync(UserStatus.DoNotDisturb);

        }

        public async Task RegisterCommandAsync()
        {
            _client.MessageReceived += HandleMessageAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        public async Task HandleMessageAsync(SocketMessage socketMessage)
        {
            var message = socketMessage as SocketUserMessage;
            var context = new IFSocketCommandContext(_client, message) as ICommandContext;

            if (message.Author.IsBot)
                return;

            int argPos = 0;

            if (message.HasStringPrefix("i!", ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess)
                    Console.WriteLine("Error on command: " + message.Content);

            }
        }

        public Task Log(LogMessage log)
        {
            Console.WriteLine(log);
            return Task.CompletedTask;
        }
    }
}
