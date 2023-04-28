using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Address;

namespace tagme3a_back_end.BL.Managers.address
{
    public interface IAddressManager
    {
        public IEnumerable<AddressReadDTO> GetAll();
        public bool AddAddress(AddressAddDTO addDTO);

        public bool RemoveAddress(int id);

        public bool UpdateAddress(int id , AddressAddDTO addressAddDTO);

    }
}
