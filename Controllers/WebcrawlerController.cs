using System;
using System.Threading.Tasks;
using hello_dotnet_mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace hello_dotnet_mvc.Controllers {
    public class WebcrawlerController : Controller {
        public IActionResult Index(string url) {
            return Json(url);
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(string url) {
            var webcrawlerService = new WebcrawlerService(new TimeSpan(0, 0, 5));
            return Json(await webcrawlerService.CrawlAsync(url));
        }
    }
}