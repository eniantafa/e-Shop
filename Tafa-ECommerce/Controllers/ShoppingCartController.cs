using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tafa_ECommerce.Intefaces;
using Tafa_ECommerce.Models;
using Tafa_ECommerce.ViewModels;

namespace Tafa_ECommerce.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IClothRepository _clothRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IClothRepository clothRepository, ShoppingCart shoppingCart)
        {
            _clothRepository = clothRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(sCVM);
        }

        public RedirectToActionResult AddToShoppingCart (int clothId)
        {
            var selectedCloth = _clothRepository.Clothes.FirstOrDefault(p => p.ClothesId == clothId);

            if(selectedCloth != null)
            {
                _shoppingCart.AddToCart(selectedCloth, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int clothId)
        {
            var selectedCloth = _clothRepository.Clothes.FirstOrDefault(p => p.ClothesId == clothId);

            if (selectedCloth != null)
            {
                _shoppingCart.RemoveFromCart(selectedCloth);
            }

            return RedirectToAction("Index");
        }
    }
}