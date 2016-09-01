using CrowBot.Commands.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrowBot.Commands
{
    /// <summary>
    /// See <see cref="ICommandFactory"/>
    /// </summary>
    public class CommandFactory: ICommandFactory
    {
        /// <summary>
        /// Stored types with the attribute <see cref="ChatName"/>
        /// </summary>
        private static Dictionary<string, Type> commands = new Dictionary<string, Type>();

        /// <summary>
        /// Static constructor to populate <see cref="commands"/>
        /// </summary>
        static CommandFactory()
        {
            var commandsWithName = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(Command).IsAssignableFrom(t))
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .Select(t => 
                    new { type = t, (t.GetCustomAttributes(typeof(ChatName), false).FirstOrDefault() as ChatName).Name }
                );

            commands = commandsWithName.ToDictionary(c => c.Name, c => c.type);
        }
        
        /// <summary>
        /// For more information, look at <see cref="ICommandFactory.CreateCommandByName(string)"/>
        /// </summary>
        public Command CreateCommandByName(string chatName)
        {
            Type commandType = commands[chatName];

            return Activator.CreateInstance(commandType) as Command;
        }
    }
}
