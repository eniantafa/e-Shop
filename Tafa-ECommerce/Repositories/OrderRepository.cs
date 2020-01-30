using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tafa_ECommerce.Intefaces;
using Tafa_ECommerce.Models;

namespace Tafa_ECommerce.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    ClothId = item.Cloth.ClothesId,
                    OrderId = order.OrderId,
                    Price = item.Cloth.Price
                };

                _appDbContext.OrderDetails.Add(orderDetail);
                    
            }

            _appDbContext.SaveChanges();
        }
    }
}
