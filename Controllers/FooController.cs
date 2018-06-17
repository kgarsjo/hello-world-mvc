using hello_dotnet_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace hello_dotnet_mvc.Controllers {
    public class FooController : Controller {
        public IActionResult Index() {
            return Json(new Greeting { Id = 1, Name = "Foo" });
        }
    }
}
