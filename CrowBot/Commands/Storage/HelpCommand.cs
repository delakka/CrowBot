using CrowBot.Commands.Attributes;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowBot.Commands.Storage
{
    [ChatName("help")]
    public class HelpCommand: Command
    {
        /// <summary>
        /// Default contructor
        /// </summary>
        public HelpCommand()
        {

        }

        /// <summary>
        /// For more information, look at <see cref="Command.Run(MessageEventArgs)"/>
        /// </summary>
        public override async Task Run(MessageEventArgs message)
        {
            await message.Channel.SendMessage("help invoked");
        }

        /// <summary>
        /// For more information, look at <see cref="Command.RunHelp(MessageEventArgs)"/>
        /// </summary>
        public override async Task RunHelp(MessageEventArgs message)
        {

        }
    }
}
