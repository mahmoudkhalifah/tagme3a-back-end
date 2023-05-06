using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.ProductOrder;

namespace tagme3a_back_end.BL.Managers.ProductOrder
{
    public class ProductOrderManager : IProductOrderManager
    {
        private readonly OrderManager orderManager;
        public ProductOrderManager(OrderManager orderManager1) 
        {
            this.orderManager = orderManager1;
        }
        public void AddProductOrder(List<ProductOrderDTO> OrdOrder,string userId)
        {
            var getOrderId = orderManager.OrderByUserID(userId);
            int orderId = getOrderId.Id;//getUserID Tmam

        }
    }
}
