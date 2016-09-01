using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowBot.Commands.Enums
{
    /// <summary>
    /// Type of a <see cref="CommandParameter"/>
    /// </summary>
    public enum ParameterType
    {
        Required,
        Optional,
        AdminOnly
    }
}
