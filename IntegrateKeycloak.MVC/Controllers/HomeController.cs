using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (User.IsInRole("administrator"))
        {
            return RedirectToAction(nameof(Admin));
        }
        else if (User.IsInRole("visitor"))
        {
            return RedirectToAction(nameof(Visitor));
        }
        else
        {
            //return Content("User does not have an appropriate role.");
            return View();
        }

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Authorize(Roles = "administrator")]
    public IActionResult Admin()
    {
        ViewBag.Username = User.Identity.Name;
        return View();
    }

    [Authorize(Roles = "visitor")]
    public IActionResult Visitor()
    {
        ViewBag.Username = User.Identity.Name;
        return View();
    }

}