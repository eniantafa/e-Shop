using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tafa_ECommerce.Intefaces;
using Tafa_ECommerce.Models;
using Tafa_ECommerce.ViewModels;

namespace Tafa_ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClothRepository _clothRepository;

        public HomeController(IClothRepository clothRepository)
        {
            _clothRepository = clothRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredClothes = _clothRepository.PreferredClothes
            };

            return View(homeViewModel);
        }
    }
}
































//public IActionResult Index()
//{
//    return View();
//}

//public IActionResult Privacy()
//{
//    return View();
//}

//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//public IActionResult Error()
//{
//    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//}
