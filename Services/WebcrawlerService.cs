using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace hello_dotnet_mvc.Services {
    public class WebcrawlerService {
        private HttpClient client { get; set; }

        public WebcrawlerService(TimeSpan timeout) {
            this.client = new HttpClient();
            this.client.Timeout = timeout;
        }

        public async Task<String> CrawlAsync(string url) {
            return await client.GetStringAsync(url); 
        }
    }
}