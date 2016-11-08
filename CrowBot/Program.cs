using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Ninject;
using CrowBot.Services;
using CrowBot.Commands;
using System.Reflection;
using System.Configuration;
using CrowBot.NinjectModules;

namespace CrowBot
{
    public class Program
    {
        /// <summary>
        /// The discord client.
        /// </summary>
        private static DiscordClient _client;

        /// <summary>
        /// The command scanner.
        /// </summary>
        private static ICommandScanner _commandScanner;

        /// <summary>
        /// The prefix of the commands.
        /// </summary>
        private static string CommandPrefix = "+";

        public static IKernel Container;

        /// <summary>
        /// Entry point of the program.
        /// </summary>
        /// <param name="args">Input arguments.</param>
        static void Main(string[] args)
        {
            #region ninject init

            Container = new StandardKernel();
            Container.Load(new NinjectBindings());
            _commandScanner = Container.Get<CommandScanner>();

            #endregion

            #region set up discord client

            var config = new DiscordConfigBuilder
            {
                LogLevel = LogSeverity.Debug,

            }.Build();
            _client = new DiscordClient(config);

            _client.MessageReceived += HandleMessage;

            _commandScanner.SetDiscordClient(_client);

            #endregion

            string token = ConfigurationManager.AppSettings["BotToken"];

            _client.ExecuteAndWait(async () =>
            {
                await _client.Connect(token, TokenType.Bot);
            });
            
        }

        /// <summary>
        /// Custom event handler for discord messages.
        /// </summary>
        /// <remarks>
        /// The discord client's <see cref="DiscordClient.MessageReceived"/> handler is being extended with this one.
        /// </remarks>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event message with all sorts of information to use.</param>
        private static void HandleMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.IsAuthor) return;

            if(e.Message.Text != null && e.Message.Text != "" && e.Message.Text.StartsWith(CommandPrefix))
            {
                Console.WriteLine(e.Message);
                _commandScanner.Scan(e);
            }
            else
            {
                // invoke reply scanner
            }
        }
    }
}
