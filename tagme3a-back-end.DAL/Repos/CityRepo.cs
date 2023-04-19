using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Context;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.DAL.Repos
{
    public class CityRepo : ICityRepo
    {
        private readonly MainDbContext _context;

        public CityRepo(MainDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<City> getAll()
        {
            return _context.Set<City>();
        }

    }
}
