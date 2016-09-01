using CrowBot.Commands.Attributes;
using CrowBot.Commands.Enums;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowBot.Commands.Storage
{
    [ChatName("vorici")]
    public class VoriciCommand: Command
    {
        /// <summary>
        /// Default contructor
        /// </summary>
        public VoriciCommand()
        {
            Parameters.Add(new CommandParameter("vorici"));

            Parameters.Add(new CommandParameter("socket", ParameterType.Required, false));

            Parameters.Add(new CommandParameter("str"));
            Parameters.Add(new CommandParameter("dex"));
            Parameters.Add(new CommandParameter("int"));

            Parameters.Add(new CommandParameter("red"));
            Parameters.Add(new CommandParameter("green"));
            Parameters.Add(new CommandParameter("blue"));
        }

        /// <summary>
        /// For more information, look at <see cref="Command.Run(MessageEventArgs)"/>
        /// </summary>
        public override async Task Run(MessageEventArgs message)
        {
            await message.Channel.SendMessage("vorici invoked");
            foreach(var prm in Parameters)
            {
                Console.WriteLine("Name: " + prm.Name + " | Value: " + prm.Value);
            }

            //int socket = Parameters.Where(p => p.Name == "socket").Select(p => { return p.Value; });

            List<Recipe> voriciRecipes = new List<Recipe>
            {
                new Recipe(1, 0),
                new Recipe(4, 2, red: 1),
                new Recipe(4, 2, green: 1),
                new Recipe(4, 2, blue: 1),
                new Recipe(25, 3, red: 2),
                new Recipe(25, 3, green: 2),
                new Recipe(25, 3, blue: 2),
                new Recipe(15, 4, red: 1, green: 1),
                new Recipe(15, 4, red: 1, blue: 1),
                new Recipe(15, 4, green: 1, blue: 1),
                new Recipe(285, 6, red: 3),
                new Recipe(285, 6, green: 3),
                new Recipe(285, 6, blue: 3),
                new Recipe(100, 7, red: 2, green: 1),
                new Recipe(100, 7, red: 2, blue: 1),
                new Recipe(100, 7, red: 1, green: 2),
                new Recipe(100, 7, green: 2, blue: 1),
                new Recipe(100, 7, red: 1, blue: 2),
                new Recipe(100, 7, green: 1, blue: 2)
            };
        }

        /// <summary>
        /// For more information, look at <see cref="Command.RunHelp(MessageEventArgs)"/>
        /// </summary>
        public override async Task RunHelp(MessageEventArgs message)
        {

        }

        #region Vorici-specific utils

        /// <summary>
        /// Class for existing vorici recipes
        /// </summary>
        private class Recipe
        {
            /// <summary>
            /// Number of red sockets to get
            /// </summary>
            public int Red { get; set; }
            /// <summary>
            /// Number of green sockets to get
            /// </summary>
            public int Green { get; set; }
            /// <summary>
            /// Number of blue sockets to get
            /// </summary>
            public int Blue { get; set; }
            /// <summary>
            /// Cost of the recipe at Vorici
            /// </summary>
            public int Cost { get; set; }
            /// <summary>
            /// Required Vorici level
            /// </summary>
            public int Level { get; set; }

            /// <summary>
            /// Default constructor
            /// </summary>
            /// <param name="cost">Cost of the recipe at Vorici</param>
            /// <param name="level">Required Vorici level</param>
            /// <param name="red">Number of red sockets to get</param>
            /// <param name="green">Number of green sockets to get</param>
            /// <param name="blue">Number of blue sockets to get</param>
            public Recipe(int cost, int level, int red = 0, int green = 0, int blue = 0)
            {
                Red = red;
                Green = green;
                Blue = blue;
                Cost = cost;
                Level = level;
            }
        }

        private class Option
        {
            /// <summary>
            /// The method of the crafting (i.e vorici or chrome)
            /// </summary>
            public string CraftingMethod { get; set; }
            public int Chance { get; set; }
            public int AvrAttempts { get; set; }
            public int Cost { get; set; }
            public int AvrCost { get; set; }
            public int StdDeviation { get; set; }
        }

        private enum CraftingMethod
        {
            Chromatic,
            Vorici
        }

        #endregion
    }
}
