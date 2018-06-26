using System;
using System.Threading.Tasks;
using hello_dotnet_mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace hello_dotnet_mvc.Controllers {
    public class WebcrawlerController : Controller {
        
        private WebcrawlerService webcrawlerService { get; set; }

        public WebcrawlerController() {
            this.webcrawlerService = new WebcrawlerService(
                new TimeSpan(0, 0, 5)
            );
        }
        public IActionResult Index(string url) {
            return Json(url);
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(string url) {
            return Json(await webcrawlerService.CrawlAsync(url));
        }
    }
}