using ASPprojekt.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASPprojekt.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserModel userModel)
        {
            //Kolla av inlogg
            bool validUser = CheckUser(userModel);


            if (validUser == true)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, userModel.email));

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(identity));

                return RedirectToAction("Index","Home");
            }
            else
            {
                @ViewBag.ErrorMessage = "Något blev fel! Du är inte inloggad!";
                return View();
            }

           
        }
        private bool CheckUser(UserModel userModel)
        {
            //hårdkodat inlogg
            if(userModel.email.ToUpper()=="USER@USER.SE" && userModel.password=="123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Loggar ut användaren vid tryck på knappen "Logga ut"//
        public async Task<IActionResult> SignOutUser()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            
            return RedirectToAction("Index", "Home");
        }
    }
}
