﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using CrowBot.Commands;
using CrowBot.Services;
using CrowBot.Commands.Storage;
using CrowBot.Commands.Attributes;

namespace CrowBot
{
    public class NinjectBindings: Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ICommandScanner>().To<CommandScanner>();
            Bind<ICommandFactory>().To<CommandFactory>();
            //Bind<IRedditClient>().To<RedditClient>();
            Bind<IPoeWikiClient>().To<PoeWikiClient>().WhenInjectedInto<PoeWikiCommand>();
        }
    }
}
