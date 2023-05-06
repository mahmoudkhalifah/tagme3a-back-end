
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.BL.DTOs.Address
{
    public record AddressReadDTO
    {
        public int Id { get; set; }
        public string ApartementNumber { get; set; } = string.Empty;
        public int FloorNumber { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string? NearestLandmark { get; set; }
        public string CityName { get; set; } = string.Empty;

    }
}
