using CrowBot.Commands.Enums;
using Discord;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowBot.Commands
{
    /// <summary>
    /// A base class for all crowbot chat commands.
    /// </summary>
    /// <remarks>
    /// Inherited classes must override the method <see cref="Run(MessageEventArgs)"/>
    /// </remarks>
    public abstract class Command
    {
        /// <summary>
        /// Command parameters, see <see cref="CommandParameter"/> for further info.
        /// </summary>
        public IList<CommandParameter> Parameters;

        public Command()
        {
            Parameters = new List<CommandParameter>();
        }
        /// <summary>
        /// Default parametrized constructor that should usually be called.
        /// </summary>
        /// <param name="name">The name (alias) of the command.</param>
        /// <param name="parameters">The command's parameters (if there's any)</param>
        public Command(IList<CommandParameter> parameters = null)
        {
            Parameters = parameters;
        }

        /// <summary>
        /// Checks if the parameters are valid.
        /// </summary>
        /// <remarks>
        /// Should be called after parsing a command from an event message.
        /// </remarks>
        /// <returns>True, if everything is fine.</returns>
        public bool CheckParameters()
        {
            foreach (CommandParameter parameter in Parameters)
            {
                if (parameter.Type == ParameterType.Required && parameter.Missing)
                {
                    return false;
                }
                else if (!parameter.Valueless && (parameter.Value == null || parameter.Value == ""))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Runs the command.
        /// </summary>
        /// <param name="message">The event message.</param>
        public abstract Task Run(MessageEventArgs message);

        /// <summary>
        /// Runs the help of this command.
        /// </summary>
        /// <param name="message">The event message.</param>
        abstract public Task RunHelp(MessageEventArgs message);
    }
}
