using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.ProductOrder;

namespace tagme3a_back_end.BL.Managers.ProductOrder
{
    public interface IProductOrderManager
    {
        public void AddProductOrder(List<ProductOrderDTO> OrdOrder, string userId);
    }
}
