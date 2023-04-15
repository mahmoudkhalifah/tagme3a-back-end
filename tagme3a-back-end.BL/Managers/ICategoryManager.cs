using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Category;

namespace tagme3a_back_end.BL.Managers
{
    public interface ICategoryManager
    {
        IEnumerable<CategoryDTO> GetAll();
        public CategoryDTO GetDetails(int id);
        public void Insert(CategoryInsertDTO category);
        public void UpdateCategory(int id, CategoryInsertDTO category);
        public void DeleteCategory(int id);
    }
}
