using CrowBot.Commands.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowBot.Commands
{
    /// <summary>
    /// A parameter of a <see cref="Command"/>
    /// </summary>
    public class CommandParameter
    {
        /// <summary>
        /// The name of the parameter
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The value of the parameter
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Determines the <see cref="ParameterType"/> of the parameter
        /// </summary>
        public ParameterType Type { get; set; }
        /// <summary>
        /// Determines whether the parameter can have a value or not.
        /// </summary>
        public bool Valueless { get; private set; }
        /// <summary>
        /// True, if the parameter is missing from the input.
        /// </summary>
        public bool Missing { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="type">The <see cref="ParameterType"/> of the parameter. Optional by default.</param>
        /// <param name="valueless">True, if the parameter can't have a value. True by default.</param>
        public CommandParameter(string name, ParameterType type = ParameterType.Optional, bool valueless = true)
        {
            Name = name;
            Type = type;
            Valueless = valueless;
            Missing = true;
        }
    }
}
