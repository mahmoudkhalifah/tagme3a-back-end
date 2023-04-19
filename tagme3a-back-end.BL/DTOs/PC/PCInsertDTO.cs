using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.BL.DTOs.PC
{
    public class PCInsertDTO
    {
        public string BundleName { get; set; }  = string.Empty;

        public string Image { set; get; } = string.Empty;
        public decimal TotalPrice { get; set; }
        //public List<int> ProductId { get; set; } = new List<int>();
        //public List<int> Quantity { get; set; } = new List<int>();


    }
}
