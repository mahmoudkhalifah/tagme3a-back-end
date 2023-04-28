using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.OrderDTO;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.Managers
{
    public interface IOrderManager
    {
        IEnumerable<OrderReadDTO> GetAll();

        List< ProductOrdersReadInOrderDTO> GetProductOrdersReadInOrder(int id);

        CitynameOrderReadDTO GetWithAddressWithCityId(int id);

        OrderReadDetailsDTO GetOrderReadDetails(int id);

        void postOrder(OrderPostDTO orderPost);

        OrderPutDTO UpdateOrder(int id, OrderPutDTO orderPut);


        OrderCityNameproducts CityNameproducts(int id);
        IEnumerable<OrderCityNameproducts> OrderByUserID(string ID);

        public GetOrderByID GetOrderById(int id);
    }

}
