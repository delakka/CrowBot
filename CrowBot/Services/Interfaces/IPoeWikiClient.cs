﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowBot.Services
{
    interface IPoeWikiClient
    {
        Task<string> GetItem(string itemName);
    }
}
