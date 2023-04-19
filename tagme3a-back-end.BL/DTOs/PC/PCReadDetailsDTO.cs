using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.BL.DTOs.PC
{
    public class PCReadDetailsDTO
    {
        public int Id { get; set; }
        public string BundleName { get; set; } = string.Empty;

        public byte[]? Image { set; get; }

        public decimal TotalPrice { get; set; }


        public IEnumerable<ProductReadDetailsInPCDTO> products { get; set; } = new List<ProductReadDetailsInPCDTO>();
    }
}
