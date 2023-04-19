using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.City;

namespace tagme3a_back_end.BL.Managers.City
{
    public interface ICityManager
    {
        public IEnumerable<CityReadDTO> GetAll();

    }
}
