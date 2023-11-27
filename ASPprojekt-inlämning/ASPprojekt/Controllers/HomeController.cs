using ASPprojekt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPprojekt.Controllers
{

    
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult BliMedlem()
    {
        return View();
    }
    public IActionResult OmOss()
    {
        return View();
    }
}
}