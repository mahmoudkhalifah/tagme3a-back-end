using Microsoft.EntityFrameworkCore;
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
    public class AddressRepo : IAddressRepo
    {
        private readonly MainDbContext _context;

        public AddressRepo(MainDbContext context)
        {
            this._context = context;
        }
        public bool AddAddress(Address address)
        {
            if(address == null)
            {
                return false;
            }
            try
            {

                _context.Addresses.Add(address);
                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAddress(int id)
        {
           var AddressToDel = _context.Set<Address>()
                .FirstOrDefault(e => e.AddressId == id);
            if (AddressToDel == null)
            {
                return false;
            }

            try
            {
                _context.Remove(AddressToDel);
                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int GetAddressIdbyUID(string UID)
        {
            var Address = _context.Addresses.FirstOrDefault(e => e.UserId == UID);
            if (Address == null)
                return 0;
            return Address.AddressId ;
        }

        public IEnumerable<Address> getAll()
        {
            return _context.Set<Address>().Include(o=>o.City);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public bool UpdateAddress(int id ,Address address)
        {
            var AddressToUpdate = _context.Set<Address>()
                .FirstOrDefault(a => a.AddressId == id);
            if (AddressToUpdate == null)
            {
                return false;
            }
            try
            {
                AddressToUpdate.ApartementNumber = address.ApartementNumber;
                AddressToUpdate.Area = address.Area;
                AddressToUpdate.Floornumber = address.Floornumber;
                AddressToUpdate.NearestLandmark = address.NearestLandmark;
                AddressToUpdate.StreetName = address.StreetName;
                AddressToUpdate.ZipCode = address.ZipCode;
                AddressToUpdate.CityId = address.CityId;
                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
