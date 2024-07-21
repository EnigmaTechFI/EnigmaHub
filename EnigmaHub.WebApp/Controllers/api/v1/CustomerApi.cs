using Microsoft.AspNetCore.Mvc;

namespace EnigmaHub.WebApp.Controllers.api.v1;

public class CustomerApi : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}