using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.ProductOrder;
using tagme3a_back_end.DAL.RepoInterfaces;
using tagme3a_back_end.DAL.Repos;

namespace tagme3a_back_end.BL.Managers.PrpductOrderManager
{
    public interface IPOManager
    {


        public void AddProductOrder(string UID);
    }
}
