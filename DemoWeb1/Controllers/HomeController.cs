using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoWeb1.Models;

namespace DemoWeb1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Person p = new Person();
        p.Name = "";
        ViewData["name"] = p.Name;
        return View(p);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index([Bind("Name")] Person p)
    {
        ViewData["name"] = p.Name;
        p.Name = "";
        return View(p);
    }
    
    //public IActionResult Hello()
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public JsonResult sayHello(string name) {
        return Json(new {msg=string.Format("Hi {0}!", name)});
    }
}
