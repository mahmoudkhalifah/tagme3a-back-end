using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.BL.DTOs.Category
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Image { set; get; }
        public bool InJourneyMode { get; set; }
        public int? OrderForJourneyMode { get; set; }
        public CategoryDTO(int Id, string Name, string Description, byte[]? Image, bool InJourneyMode
      , int? OrderForJourneyMode)
        {
            this.Description = Description;
            CategoryId = Id;
            this.Name = Name;
            this.Image = Image;
            this.InJourneyMode = InJourneyMode;
            this.OrderForJourneyMode = OrderForJourneyMode;
        }
    }
}
