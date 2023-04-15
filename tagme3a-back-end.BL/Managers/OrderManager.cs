using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.OrderDTO;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.BL.Managers
{
    public  class OrderManager :IOrderManager
    {
        private readonly IOrderRepo _orderRepo;

        public OrderManager(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public IEnumerable<OrderReadDTO> GetAll()
        {
            var Orders = _orderRepo.GetAll();
            if(Orders != null)
            {
                return Orders.Select(d => new OrderReadDTO
                {

                    Id = d.Id,
                    Address = new AddressReadinOrderDTO
                    {
                        StreetName = d.Address.StreetName,
                        ApartementNumber = d.Address.ApartementNumber,
                        Floornumber = d.Address.Floornumber,
                        Area = d.Address.Area,
                        ZipCode = d.Address.ZipCode
                    },
                    Bill = d.Bill,
                    OrderDate = d.OrderDate,
                    ShippingDate = d.ShippingDate,
                    ArrivalDate = d.ArrivalDate,
                    OrderState = d.OrderState,
                    PayMethod = d.PayMethod,
                    UserName = d.User.UserName
                }).ToList();

            }
            return null;

        }

        public OrderReadDetailsDTO GetOrderReadDetails(int id)
        {
            Order? OrderFromDb = _orderRepo.GetWithMoreDetails(id);

            if (OrderFromDb is null)
            {
                return null;
            }

            return new OrderReadDetailsDTO
            {
                Id = OrderFromDb.Id,
                Bill = OrderFromDb.Bill,
                OrderDate = OrderFromDb.OrderDate,
                ShippingDate = OrderFromDb.ShippingDate,
                ArrivalDate = OrderFromDb.ArrivalDate,
                OrderState = OrderFromDb.OrderState,
                PayMethod = OrderFromDb.PayMethod,
                Address = new AddressReadinOrderDTO
                {
                    CityName = OrderFromDb.Address.City.Name,
                    ApartementNumber = OrderFromDb.Address.ApartementNumber,
                    Floornumber = OrderFromDb.Address.Floornumber,
                    StreetName = OrderFromDb.Address.StreetName,
                    Area = OrderFromDb.Address.Area,
                    ZipCode = OrderFromDb.Address.ZipCode

                },
                User = new UserReadInOrderDTO
                {
                    Fname=OrderFromDb.User.Fname,
                    Lname =OrderFromDb.User.Lname,
                     userName =OrderFromDb.User.UserName,
                },
                ProductOrdersReadInOrder = OrderFromDb.ProductOrders
                .Select(p => new ProductOrdersReadInOrderDTO
                {
                    ProductName=p.Product.Name,
                    Quantiy=p.Quantiy


                })
            };
        }

        public List<ProductOrdersReadInOrderDTO> GetProductOrdersReadInOrder(int id)
        {
            var Order = _orderRepo.GetWithProduct(id);
            if (Order == null)
            {
                return null;
            }
             var productOrders = Order.ProductOrders.Select(po =>
             new ProductOrdersReadInOrderDTO
             {
                 ProductName = po.Product.Name,
                 Quantiy = po.Quantiy
             }).ToList();

            return productOrders;


        }

        public CitynameOrderReadDTO GetWithAddressWithCityId(int id)
        {
            Order? OrderFromDb = _orderRepo.GetWithAddressWithCityId(id);

            if (OrderFromDb is null)
            {
                return null;
            }

            return new CitynameOrderReadDTO
            {
                Id = OrderFromDb.Id,
                Bill = OrderFromDb.Bill,
                OrderDate = OrderFromDb.OrderDate,
                ShippingDate = OrderFromDb.ShippingDate,
                ArrivalDate = OrderFromDb.ArrivalDate,
                OrderState = OrderFromDb.OrderState,
                PayMethod = OrderFromDb.PayMethod,
                UserName = OrderFromDb.User.UserName,
                CityName = OrderFromDb.Address.City.Name,      
            };
        }

        public void postOrder(int AddressID, decimal Bill, DateTime OrderDate, DateTime ShippingDate, DateTime ArrivalDate, OrderState OrderState, PayMethod PayMethod, string UserId)
        {
            Order order = new Order()
            {
               AddressID=AddressID,
               Bill=Bill,
               OrderDate=OrderDate,
               ShippingDate=ShippingDate,
               ArrivalDate=ArrivalDate,
               OrderState = OrderState,
               PayMethod = PayMethod,
               UserId = UserId

            };
            _orderRepo.Insert(order);
        }

        //Put
        public OrderPutDTO UpdateOrder(int id, OrderPutDTO orderPut)
        {
            var order = _orderRepo.GetOrder(id);
            if(order != null)
            {
                order.AddressID = orderPut.AddressID;
                order.Bill = orderPut.Bill;
                order.OrderDate = orderPut.OrderDate;
                order.ShippingDate = orderPut.ShippingDate;
                order.ArrivalDate = orderPut.ArrivalDate;
                order.OrderState = orderPut.OrderState;
                order.PayMethod = orderPut.PayMethod;
                order.UserId = orderPut.UserId;
               _orderRepo.Update(orderPut.ID, order);
               return orderPut;
            }
            return null;
        }
    }
}
