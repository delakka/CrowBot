using CrowBot.Commands.Attributes;
using CrowBot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Ninject;

namespace CrowBot.Commands.Storage
{
    [ChatName("wiki")]
    class PoeWikiCommand: Command
    {
        
        private IPoeWikiClient _wikiClient;
        /// <summary>
        /// The poe wiki rest client.
        /// </summary>
        [Inject]
        public IPoeWikiClient PoeWikiClient
        {
            get { return _wikiClient; }
            set { _wikiClient = value; }
        }

        public PoeWikiCommand()
        {
            Parameters.Add(new CommandParameter("wiki", valueless: false));
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="wikiClient">The injected poe wiki client</param>
        //public PoeWikiCommand(IPoeWikiClient wikiClient)
        //{
        //    _wikiClient = wikiClient;

        //    Parameters.Add(new CommandParameter("wiki", valueless: false));
        //}

        /// <summary>
        /// For more information, look at <see cref="Command.Run(MessageEventArgs)"/>
        /// </summary>
        public async override Task Run(MessageEventArgs message)
        {
            string itemName = Parameters.Where(p => p.Name == "wiki")
                .Select(p => { return p.Value; }).FirstOrDefault();

            string url = await _wikiClient.GetItem(itemName);

            await message.Channel.SendMessage(url);
        }

        /// <summary>
        /// For more information, look at <see cref="Command.RunHelp(MessageEventArgs)"/>
        /// </summary>
        public override Task RunHelp(MessageEventArgs message)
        {
            throw new NotImplementedException();
        }
    }
}
