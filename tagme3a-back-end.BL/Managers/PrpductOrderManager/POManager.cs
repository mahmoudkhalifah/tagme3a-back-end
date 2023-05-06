using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Product;
using tagme3a_back_end.BL.DTOs.ProductOrder;
using tagme3a_back_end.BL.Managers.ProductManager;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.BL.Managers.PrpductOrderManager
{
    public class POManager : IPOManager
    {
        private readonly IProductOrderRepo _iPORepo;
        private readonly IOrderManager _orderManager;
        private readonly IProductRepo _productManager;


        private readonly IUserProductInCartManager _userProductInCart;
        public POManager(IProductOrderRepo iPORepo, IUserProductInCartManager userProductInCart,
            IOrderManager orderManager, IProductRepo productManager)
        {
            this._iPORepo = iPORepo;
            this._userProductInCart=userProductInCart;
            this._orderManager = orderManager;
            this._productManager= productManager;
        }
        public void AddProductOrder(string UID)
        {
            var prds = _userProductInCart.GetUserCartPrdName(UID);
            var OrderID=_orderManager.GetOrderLastID(UID);

            IEnumerable<ProductOrder> products = new List<ProductOrder>();

            products = prds.Select(p => new ProductOrder
            {
                OrderId = OrderID,
                ProductId = p.PID,
                Quantiy = p.Quantity
            });


            foreach (var product in prds) 
            {
                var prd = _productManager.GetProductById(product.PID);
                prd.UnitInStocks-=product.Quantity;
                _productManager.UpdateProduct(prd, prd.Id);
            }

            _iPORepo.AddProductOrder(products);
        }

    
       
    }
}
