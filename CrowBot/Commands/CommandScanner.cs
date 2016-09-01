using CrowBot.Commands.Util;
using CrowBot.Services;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowBot.Commands
{
    /// <summary>
    /// Class scanning for existing commands and executing them via services.
    /// </summary>
    public class CommandScanner: ICommandScanner
    {
        private readonly ICommandFactory _commandFactory;
        /// <summary>
        /// The discord client being used.
        /// </summary>
        private DiscordClient _discordClient;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="storage">The injected command storage</param>
        public CommandScanner(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
            _discordClient = null;
        }

        /// <summary>
        /// For more information look at <see cref="ICommandScanner.SetDiscordClient(DiscordClient)"/>
        /// </summary>
        public void SetDiscordClient(DiscordClient client)
        {
            if (_discordClient == null)
            {
                _discordClient = client;
            }
        }

        /// <summary>
        /// For more information look at <see cref="ICommandScanner.Scan(MessageEventArgs)"/>
        /// </summary>
        public async void Scan(MessageEventArgs message)
        {
            Command command = Parse(message.Message.Text.Substring(1));
            if (command == null) return;

            if (!command.CheckParameters()) return;

            await command.Run(message);
        }

        /// <summary>
        /// For more information look at <see cref="ICommandScanner.Parse(string)"/>
        /// </summary>
        public Command Parse(string text)
        {
            string commandName = text.Split('-')
                .FirstOrDefault()
                .Split(' ')
                .FirstOrDefault();

            if (commandName == null) return null;

            var command = _commandFactory.CreateCommandByName(commandName);

            if (command != null)
            {
                command.ParseParameters(text);
            }

            return command;
        }
    }
}
