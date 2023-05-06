using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Context;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.DAL.Repos
{
    public class orderRepo : IOrderRepo
    {
        MainDbContext _context { get; set; }

        public orderRepo(MainDbContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var Order = _context.Orders.Find(id);
            if(Order != null)
            {
             _context.Orders.Remove(Order);
            _context.SaveChanges();
          
            }
        }

        public IEnumerable<Order> GetAll()
        {
          return  _context.Orders.Include(e => e.Address).Include(e => e.User).Include(e=>e.ProductOrders).ToList();
        }

        public Order? GetOrder(int id)
        {

            return _context.Orders.Where(e=>e.Id==id).FirstOrDefault();

        }

        public void Insert(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(int id, Order updatedOrder)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                order.AddressID = updatedOrder.AddressID;
                order.UserId = updatedOrder.UserId;
                order.ArrivalDate = updatedOrder.ArrivalDate;
                order.Bill = updatedOrder.Bill;
                order.OrderState = updatedOrder.OrderState;
                order.PayMethod = updatedOrder.PayMethod;
                order.ShippingDate = updatedOrder.ShippingDate;
                order.OrderDate = updatedOrder.OrderDate;
                order.ProductOrders = updatedOrder.ProductOrders;
                _context.SaveChanges();

            }
        }
        public Order? GetWithAddressWithCityId(int id)
        {
            return _context.Orders.Include(e=>e.User)
                    .Include(d => d.Address)
                        .ThenInclude(p => p.City)
                    .FirstOrDefault(d => d.Id == id);

        }
        public Order? GetWithProduct(int id)
        {
            return _context.Orders
                    .Include(d => d.ProductOrders)
                        .ThenInclude(p => p.Product)
                    .FirstOrDefault(d => d.Id == id);
        }

        public Order? GetWithMoreDetails(int id)
        {
            return _context.Orders.Include(e=>e.Address).ThenInclude(e=>e.City)
                   .Include(d => d.ProductOrders)
                       .ThenInclude(p => p.Product)
                       .Include(e=>e.User)
                   .FirstOrDefault(d => d.Id == id);
        }


        public IEnumerable<Order> GetordersByUserID(string UserId)
        {
            return _context.Orders.Include(e => e.Address).ThenInclude(p=>p.City).
                Include(e => e.ProductOrders).ThenInclude(p=>p.Product).Include(e => e.User).Where(d=>d.UserId==UserId).ToList();

        }


        public int GetOrderLastID(string UID)
        {
            var Order = _context.Orders.OrderBy(e => e.Id).Last(e=>e.UserId==UID);
            if (Order == null)
                return 0;
            return Order.Id;
        }

    }
}
