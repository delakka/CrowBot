using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowBot.Commands.Attributes
{
    /// <summary>
    /// An attribute for commands, defining their names as used in chat
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ChatName: Attribute
    {
        /// <summary>
        /// Name of the command. Used for looking up a specific command
        /// </summary>
        public string Name;
        
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name">Name someone can access the command by.</param>
        public ChatName(string name)
        {
            Name = name;
        }
    }
}
