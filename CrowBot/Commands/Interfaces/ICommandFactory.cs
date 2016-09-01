using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowBot.Commands
{
    /// <summary>
    /// Interface for a factory class that creates different types of <see cref="Command"/>s.
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Creates a command that has its <see cref="ChatName"/> property with the name specified by chatName.
        /// </summary>
        /// <param name="chatName">A command name</param>
        /// <returns>A <see cref="Command"/></returns>
        Command CreateCommandByName(string chatName);
    }
}
