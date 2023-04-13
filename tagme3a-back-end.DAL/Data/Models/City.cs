using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.DAL.Data.Models
{
    public class City
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
        /*Alexandria,
        Aswan,
        Asyut,
        Beheira,
        BeniSuef,
        Cairo,
        Dakahlia,
        Damietta,
        Faiyum,
        Gharbia,
        Giza,
        Ismailia,
        KafrElSheikh,
        Luxor,
        Matrouh,
        Minya,
        Monufia,
        NewValley,
        NorthSinai,
        PortSaid,
        Qalyubia,
        Qena,
        RedSea,
        Sharqia,
        Sohag,
        SouthSinai*/
}
