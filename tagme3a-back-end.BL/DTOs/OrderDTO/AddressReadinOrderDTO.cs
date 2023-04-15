using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.DTOs.OrderDTO
{

    //ApartementNumber,Floornumber,StreetName,Area,ZipCode
    public class AddressReadinOrderDTO
    {
        public string ApartementNumber { get; set; } = string.Empty;
        public int Floornumber { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string CityName { get; set; }=string.Empty;
        public string ZipCode { get; set; } = string.Empty;

    }
}
