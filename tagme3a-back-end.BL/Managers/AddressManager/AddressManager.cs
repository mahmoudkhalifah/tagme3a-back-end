using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Address;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.BL.Managers.address
{
    public class AddressManager :IAddressManager
    {
        private readonly IAddressRepo _addressRepo;

        public AddressManager(IAddressRepo addressRepo)
        {
            _addressRepo = addressRepo;
        }

        public IEnumerable<AddressReadDTO> GetAll()
        {
            var adresses = _addressRepo.getAll();

            return adresses.Select(a => new AddressReadDTO
            {
                Id = a.AddressId,
                ApartementNumber = a.ApartementNumber,
                Area = a.Area,
                CityName = a.City?.Name??"",
                FloorNumber = a.Floornumber,
                NearestLandmark = a.NearestLandmark,
                StreetName = a.StreetName,
                ZipCode = a.ZipCode,

            });
        }

        public bool AddAddress(AddressAddDTO addDTO)
        {
            Address address = new()
            {
                Area = addDTO.Area,
                ApartementNumber = addDTO.ApartementNumber,
                Floornumber = addDTO.FloorNumber,
                NearestLandmark = addDTO.NearestLandmark,
                StreetName = addDTO.StreetName,
                ZipCode = addDTO.ZipCode,
                CityId = addDTO.CityId,
                UserId = addDTO.UserId
            };
           return _addressRepo.AddAddress(address);
        }

        public bool RemoveAddress(int id)
        {
            return _addressRepo.DeleteAddress(id);
        }

        public bool UpdateAddress(int id , AddressAddDTO addressAddDTO)
        {
            Address add = new()
            {
                AddressId = id,
                Area = addressAddDTO.Area,
                ApartementNumber = addressAddDTO.ApartementNumber,
                Floornumber = addressAddDTO.FloorNumber,
                NearestLandmark = addressAddDTO.NearestLandmark,
                StreetName = addressAddDTO.StreetName,
                ZipCode = addressAddDTO.ZipCode,
                CityId = addressAddDTO.CityId,
                UserId = addressAddDTO.UserId
            };
            return _addressRepo.UpdateAddress(id, add);
        }

        public int GetAddressIDbyUID(string UID)
        {
            return _addressRepo.GetAddressIdbyUID(UID);
        }

        public IEnumerable<AddressReadDTO> GetAddress(string id)
        {
            var adresses = _addressRepo.getAll().Where(e=>e.UserId==id).ToList();

            return adresses.Select(a => new AddressReadDTO
            {
                Id = a.AddressId,
                ApartementNumber = a.ApartementNumber,
                Area = a.Area,
                CityName = a.City?.Name ?? "",
                FloorNumber = a.Floornumber,
                NearestLandmark = a.NearestLandmark,
                StreetName = a.StreetName,
                ZipCode = a.ZipCode,

            });
        }
    }
}
