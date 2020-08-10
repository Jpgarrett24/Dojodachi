using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            if (HttpContext.Session.GetInt32("Happiness") == null)
            {
                HttpContext.Session.SetInt32("Happiness", 20);
                HttpContext.Session.SetInt32("Fullness", 20);
                HttpContext.Session.SetInt32("Energy", 50);
                HttpContext.Session.SetInt32("Meals", 3);
            }
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.Image = "https://pngimg.com/uploads/welcome/welcome_PNG27.png";
            return View("Index");
        }

        [HttpPost("")]
        public IActionResult Move(string action)
        {
            if (action == "feed")
            {
                if (HttpContext.Session.GetInt32("Meals") == 0)
                {
                    ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
                    ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
                    ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
                    ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
                    ViewBag.Image = "https://preview.pixlr.com/images/800wm/100/1/1001212814.jpg";
                    ViewBag.Response = "You don't have any meals remaining. Get to work!!!";
                    return View("Index");
                }
                Random roll = new Random();
                Random increase = new Random();
                int? meals = HttpContext.Session.GetInt32("Meals");
                HttpContext.Session.SetInt32("Meals", (int)meals - 1);
                ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
                ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
                ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
                if (roll.Next(0, 4) == 0)
                {
                    ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
                    ViewBag.Image = "https://preview.pixlr.com/images/800wm/100/1/1001212814.jpg";
                    ViewBag.Response = "You attempted to feed your Dojodachi, but it didn't like that s**t";
                }
                else
                {
                    int? gains = increase.Next(5, 11);
                    HttpContext.Session.SetInt32("Fullness", (int)HttpContext.Session.GetInt32("Fullness") + (int)gains);
                    ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
                    ViewBag.Image = "https://img.favpng.com/23/2/18/ninja-cartoon-png-favpng-m9Q8K02CZs87ScyuT8qBGKBr4.jpg";
                    ViewBag.Response = $"You just fed your Dojodachi! Meals -1, Fullness +{gains}";
                }
                // return View("Index");
            }
            if (action == "play")
            {
                if (HttpContext.Session.GetInt32("Energy") <= 5)
                {
                    ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
                    ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
                    ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
                    ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
                    ViewBag.Image = "https://preview.pixlr.com/images/800wm/100/1/1001212814.jpg";
                    ViewBag.Response = "You don't have the energy to play. You need some sleep!!!";
                    return View("Index");
                }
                ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
                ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
                ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
                HttpContext.Session.SetInt32("Energy", (int)HttpContext.Session.GetInt32("Energy") - 5);
                ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
                Random roll = new Random();
                Random increase = new Random();
                if (roll.Next(0, 5) == 0)
                {
                    ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
                    ViewBag.Image = "https://preview.pixlr.com/images/800wm/100/1/1001212814.jpg";
                    ViewBag.Response = "You attempted to play with your Dojodachi, but it wasn't in the mood";
                    // return View("Index");
                }
                else
                {
                    int? gains = increase.Next(5, 11);
                    HttpContext.Session.SetInt32("Happiness", (int)HttpContext.Session.GetInt32("Happiness") + (int)gains);
                    ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
                    ViewBag.Image = "https://img.favpng.com/23/2/18/ninja-cartoon-png-favpng-m9Q8K02CZs87ScyuT8qBGKBr4.jpg";
                    ViewBag.Response = $"You just played with your Dojodachi! Energy -5, Happiness +{gains}";
                    // return View("Index");
                }
            }
            if (action == "work")
            {
                if (HttpContext.Session.GetInt32("Energy") <= 5)
                {
                    ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
                    ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
                    ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
                    ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
                    ViewBag.Image = "https://preview.pixlr.com/images/800wm/100/1/1001212814.jpg";
                    ViewBag.Response = "You don't have the energy to work. You need some sleep!!!";
                    return View("Index");
                }
                ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
                ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
                Random roll = new Random();
                int gains = roll.Next(1, 4);
                ViewBag.Response = $"You just put in dat work! Energy -5, Meals +{gains}";
                HttpContext.Session.SetInt32("Energy", (int)HttpContext.Session.GetInt32("Energy") - 5);
                ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
                HttpContext.Session.SetInt32("Meals", (int)HttpContext.Session.GetInt32("Meals") + (int)gains);
                ViewBag.Image = "https://www.kindpng.com/picc/m/178-1789589_fighting-ninja-ninja-clipart-hd-png-download.png";
                ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
                // return View("Index");
            }
            if (action == "sleep")
            {
                ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
                HttpContext.Session.SetInt32("Energy", (int)HttpContext.Session.GetInt32("Energy") + 15);
                ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
                HttpContext.Session.SetInt32("Fullness", (int)HttpContext.Session.GetInt32("Fullness") - 5);
                ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
                HttpContext.Session.SetInt32("Happiness", (int)HttpContext.Session.GetInt32("Happiness") - 5);
                ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
                ViewBag.Response = "Your Dojodachi just rested! Energy +15, Fullness & Happiness -5";
                ViewBag.Image = "https://banner2.cleanpng.com/20180425/hae/kisspng-ninja-sleep-snoring-github-pages-blog-preserved-5ae02c52c4fc94.1243453915246408508069.jpg";
                // return View("Index");
            }
            if (action == "reset")
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index");
            }
            if (ViewBag.Fullness >= 100 && ViewBag.Happiness >= 100 && ViewBag.Energy >= 100)
            {
                ViewBag.Response = "Congratulations! You've wone!!!";
                ViewBag.Image = "https://img.favpng.com/23/2/18/ninja-cartoon-png-favpng-m9Q8K02CZs87ScyuT8qBGKBr4.jpg";
                return View("Result");
            }
            if (ViewBag.Fullness <= 0 || ViewBag.Happiness <= 0)
            {
                ViewBag.Response = "You've Failed!";
                ViewBag.Image = "https://preview.pixlr.com/images/800wm/100/1/1001212814.jpg";
                return View("Result");
            }
            return View("Index");
        }
    }
}