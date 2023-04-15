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

        void postOrder(int AddressID, decimal Bill, DateTime OrderDate, DateTime ShippingDate, DateTime ArrivalDate, OrderState OrderState, PayMethod PayMethod, String UserId);

        OrderPutDTO UpdateOrder(int id, OrderPutDTO orderPut);



    }

}
