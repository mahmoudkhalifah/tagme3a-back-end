using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.City;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.BL.Managers.City
{
    public class CityManager:ICityManager
    {
        private readonly ICityRepo _cityRepo;

        public CityManager(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public IEnumerable<CityReadDTO> GetAll()
        {
            var cities = _cityRepo.getAll();
            return cities.Select(c => new CityReadDTO(Id: c.Id, Name: c.Name));
        }
    }
}
