using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DiscordTutorialBot
{
    internal class Program
    {
        private DiscordSocketClient _client;
        private CommandHandler _commandHandler;

        public static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            if (string.IsNullOrEmpty(Config.Bot.Token)) return;
            
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });
            _client.Log += Log;
            await _client.LoginAsync(TokenType.Bot, Config.Bot.Token);
            await _client.StartAsync();
            
            _commandHandler = new CommandHandler();
            await _commandHandler.InitAsync(_client);
            await Task.Delay(-1);
        }

        private async Task Log(LogMessage message)
        {
            Console.WriteLine(message.Message);
            await Task.CompletedTask;
        }
    }
}