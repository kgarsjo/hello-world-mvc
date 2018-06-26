using Polly;
using Polly.CircuitBreaker;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace hello_dotnet_mvc.Services {
    public class WebcrawlerService {
        private Policy policy { get; set; }

        private HttpClient client { get; set; }

        public WebcrawlerService(TimeSpan timeout) {
            this.client = new HttpClient();

            this.policy = Policy.WrapAsync(
                Policy.Handle<Exception>(e => !(e is BrokenCircuitException)) 
                    .RetryAsync(1),
                Policy.BulkheadAsync(5, 10),
                Policy.TimeoutAsync(timeout.Seconds)
            );
        }

        public async Task<String> CrawlAsync(string url) {
            var pollyResult = await policy.ExecuteAndCaptureAsync(() => client.GetStringAsync(url));
            return pollyResult.Result;
        }
    }
}