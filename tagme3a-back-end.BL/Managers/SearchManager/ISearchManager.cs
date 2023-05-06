using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Product;

namespace tagme3a_back_end.BL.Managers.SearchManager
{
    public interface ISearchManager
    {
        IEnumerable<ProductReadDto> GetAllProduct(string productName);

    }
}
