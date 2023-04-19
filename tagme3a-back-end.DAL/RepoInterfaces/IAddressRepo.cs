using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.DAL.RepoInterfaces
{
    public interface IAddressRepo
    {
        IEnumerable<Address> getAll();

        bool UpdateAddress(int id ,Address address);

        bool AddAddress(Address address);

        bool DeleteAddress(int id);

        int SaveChanges();
    }
}
