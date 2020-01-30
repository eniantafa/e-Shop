using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tafa_ECommerce.Intefaces;
using Tafa_ECommerce.Models;
using Tafa_ECommerce.ViewModels;

namespace Tafa_ECommerce.Controllers
{
    public class ClothController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IClothRepository _clothRepository;

        public ClothController(ICategoryRepository categoryRepository, IClothRepository clothRepository)
        {
            _categoryRepository = categoryRepository;
            _clothRepository = clothRepository;
        }

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Cloth> clothes = null;

            string currentCategory = String.Empty;

            if(String.IsNullOrEmpty(category))
            {
                clothes = _clothRepository.Clothes.OrderBy(n => n.ClothesId);
                currentCategory = "All Drinks";
            }

            else
            {
                if(String.Equals("Girls", _category, StringComparison.OrdinalIgnoreCase))
                {
                    clothes = _clothRepository.Clothes.Where(p => p.Category.CategoryName.Equals("Girls"));
                }

                else 
                    clothes = _clothRepository.Clothes.Where(p => p.Category.CategoryName.Equals("Girls"));
                

                currentCategory = _category;
            }

            var clothListViewModel = new ClothListViewModel
            {
                Clothes = clothes,
                CurrentCategory = currentCategory
            };

            return View(clothListViewModel);
        }
    }
}
