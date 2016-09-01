using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowBot.Commands.Util
{
    /// <summary>
    /// Extension methods for parsing commands
    /// </summary>
    public static class ParserExtensions
    {
        /// <summary>
        /// Parses parameters (<see cref="CommandParameter"/>) in a command from a message.
        /// </summary>
        /// <param name="command">The <see cref="Command"/> to extend</param>
        /// <param name="message">The text message sent by a user</param>
        public static void ParseParameters(this Command command, string message)
        {
            List<string> messageParts = message.Split('-').ToList();

            foreach (string part in messageParts)
            {
                List<string> paramParts = part.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (paramParts.Count == 0) continue;

                string paramName = String.Join(String.Empty, paramParts.Take(1));
                string paramValue = paramParts.Count > 1 ? String.Join(String.Empty, paramParts.Skip(1)) : null;

                command.Parameters.Where(p => p.Name == paramName)
                    .Select(p => { p.Value = paramValue; p.Missing = false; return p; }).FirstOrDefault();
            }
        }
    }
}
