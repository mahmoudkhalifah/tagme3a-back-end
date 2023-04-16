using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.BL.DTOs.Brand
{
    public class BrandDTO
    {
        public int BrandId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Logo { get; set; }
        public BrandDTO(int Id, string Name, string Description, byte[]? Logo)
        {
            BrandId = Id;
            this.Name = Name;
            this.Description = Description;
            this.Logo = Logo;
        }
    }
}
