﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.BL.DTOs.UserProductInCart
{
    public class UserCartPrdName
    {
        public string PrdName { get; set; } = string.Empty;
        public int PID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? Discount { get; set; }
        public int? UnitInStocks { get; set; }

    }
}
