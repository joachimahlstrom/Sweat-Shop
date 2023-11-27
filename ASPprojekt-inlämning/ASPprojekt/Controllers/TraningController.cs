using ASPprojekt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPprojekt.Controllers
{
    
    public class TraningController : Controller
    {
        public IActionResult Index()
        {
            //Öppna samt att stänga databasen för minskad risk för krasch//
            using (TraningContext tOvningarDb= new TraningContext())
            {

                List<TraningModel> tOvningar = tOvningarDb.tOvningar.ToList();
                return View(tOvningar);
            }


        }

        [Authorize]
        //Endast inloggade användare kommer åt denna sidan//
        public IActionResult Create()
        {
            return View();
      }
        [HttpPost]
        //här lägger den inloggade användaren in ny övningar.//
        public IActionResult Create(TraningModel nyOvning)
        {
              using(TraningContext db= new TraningContext())
           {
               db.tOvningar.Add(nyOvning);
               db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        


    }
}
