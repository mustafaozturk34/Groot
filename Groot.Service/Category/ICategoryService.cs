using Groot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groot.Service.Category
{
    public interface ICategoryService
    {
        public General<Model.Category.Category> Insert(Model.Category.Category newCategory);
        public General<Model.Category.Category> GetCategory();
        public General<Model.Category.Category> Update(int id, Model.Category.Category category);
        public General<Model.Category.Category> Delete(int id);
    }
}
