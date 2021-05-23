using StoreApp.BusinessLogic.BusinessEntities;
using StoreApp.DataAccess;
using StoreApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.BusinessLogic
{
    public class OrderHandler
    {
        private readonly OrderRepository<Order> orderRepo;
        private readonly AddressRepository<Address> addressRepo;
        private readonly GenericRepository<OrdersProduct> orderProdRepo;
        public OrderHandler()
        {
            orderRepo = new OrderRepository<Order>();
            addressRepo = new AddressRepository<Address>();
            orderProdRepo = new GenericRepository<OrdersProduct>();
        }

        public void PlaceOrder(int productId,int quantity,int userId, int addressId)
        {
            var order = new Order
            {
                AddressId = addressId,
                OrderDate = DateTime.Now,
                UserId = userId
            };
          var orderId=  orderRepo.CreateAddressandGetId(order);
            var orderProduct = new OrdersProduct
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = quantity
            };
            orderProdRepo.Create(orderProduct);

        }

        public int CreateAddressAndGetId(AddressModel model)
        {
            var address = new Address
            {
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                City = model.City,
                Postcode = model.Postcode,
                Province = model.Province
            };
            return addressRepo.CreateAddressandGetId(address);
        }
    


    }
}
