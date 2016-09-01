using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowBot.Commands
{
    /// <summary>
    /// Scans and executes commands received through a <see cref="DiscordClient"/>'s event messages.
    /// </summary>
    public interface ICommandScanner
    {
        void SetDiscordClient(DiscordClient client);
        /// <summary>
        /// Scans the event message for a command, then parses and executes it.
        /// </summary>
        /// <param name="message">The event message</param>
        void Scan(MessageEventArgs message);
    }
}
