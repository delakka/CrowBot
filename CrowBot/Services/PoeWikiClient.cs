using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowBot.Services
{
    class PoeWikiClient: IPoeWikiClient
    {
        /// <summary>
        /// The rest client
        /// </summary>
        private readonly RestClient _client;

        /// <summary>
        /// default constructor
        /// </summary>
        public PoeWikiClient()
        {
            _client = new RestClient()
            {
                BaseUrl = new Uri("http://pathofexile.gamepedia.com/index.php")
            };
        }

        /// <summary>
        /// For more information, see <see cref="IPoeWikiClient.GetItem(string)"/>
        /// </summary>
        public async Task<string> GetItem(string itemName)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("search", itemName);

            var response = await _client.ExecuteTaskAsync(request);

            return response.ResponseUri.AbsoluteUri;
        }
    }
}
