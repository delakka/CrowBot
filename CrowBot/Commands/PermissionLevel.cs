using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowBot.Commands
{
    /// <summary>
    /// Defines who can use a <see cref="Command"/>
    /// </summary>
    public enum PermissionLevel
    {
        /// <summary>
        /// Any discord user
        /// </summary>
        User,
        /// <summary>
        /// A user with an elevated permission level (typically the bot owner)
        /// </summary>
        Admin
    }
}
