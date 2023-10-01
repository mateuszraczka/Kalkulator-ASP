using Kalkulator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kalkulator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Imie = "Jan";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzień dobry" : "Dobry wieczór";

            Dane[] osoby =
            {
                new Dane("Anna", "Kowalski"),
                new Dane("Mateusz", "Rączka"),
                new Dane("Mariusz", "Nowak")
            };
            return View(osoby);
        }
        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie} masz {DateTime.Now.Year - urodziny.Rok} lat";
            return View();
        }

        public IActionResult KalkulatorResult(Calc kalkulator)
        {
            int wynik;

            if (kalkulator.Znak == "/")
            {
                wynik = kalkulator.Liczba1 / kalkulator.Liczba2;
            }
            else if (kalkulator.Znak == "*")
            {
                wynik = kalkulator.Liczba1 * kalkulator.Liczba2;
            }
            else if (kalkulator.Znak == "+")
            {
                wynik = kalkulator.Liczba1 + kalkulator.Liczba2;
            }
            else if (kalkulator.Znak == "-")
            {
                wynik = kalkulator.Liczba1 - kalkulator.Liczba2;
            }
            else
            {
                wynik = 0;
            }

            ViewBag.wynik = wynik;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}