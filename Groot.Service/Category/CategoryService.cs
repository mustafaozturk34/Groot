using AutoMapper;
using Groot.DB.Entities.DataContext;
using Groot.Model;
using Groot.Service.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groot.Service.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;

        public CategoryService(IMapper _mapper)
        {
            mapper = _mapper;
        }


        public General<Model.Category.Category> Insert(Model.Category.Category newCategory)
        {
            var result = new General<Model.Category.Category>() { IsSuccess = false };

            var categoryModel = mapper.Map<Groot.DB.Entities.Category>(newCategory);
            using (var srv = new GrootContext())
            {
                categoryModel.Idate = DateTime.Now;
                srv.Category.Add(categoryModel);
                srv.SaveChanges();
                result.Entity = mapper.Map<Groot.Model.Category.Category>(categoryModel);
                result.IsSuccess = true;
            }
            


            return result;
        }

        public General<Model.Category.Category> GetCategory()
        {
            var result = new General<Model.Category.Category>();

            using (var context = new GrootContext())
            {
                var data = context.Category
                    .Where(x => !x.IsActive && !x.IsDeleted)
                    .OrderBy(x => x.Id);

                if (data.Any())
                {
                    result.List = mapper.Map<List<Model.Category.Category>>(data);
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Hiçbir kategori bulunamadı.";
                }
            }

            return result;
        }

        public General<Model.Category.Category> Update(int id, Model.Category.Category category)
        {
            var result = new General<Model.Category.Category>();

            using (var context = new GrootContext())
            {
                var updateCategory = context.Category.SingleOrDefault(i => i.Id == id);

                if (updateCategory is not null)
                {
                    updateCategory.Name = category.Name;
                    updateCategory.DisplayName= category.DisplayName;


                    context.SaveChanges();

                    result.Entity = mapper.Map<Model.Category.Category>(updateCategory);
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Hiçbir kategori bulunamadı.";
                }
            }

            return result;
        }

        public General<Model.Category.Category> Delete(int id)
        {
            var result = new General<Model.Category.Category>();

            using (var context = new GrootContext())
            {
                var category = context.Category.SingleOrDefault(i => i.Id == id);

                if (category is not null)
                {
                    context.Category.Remove(category);
                    context.SaveChanges();

                    result.Entity = mapper.Map<Model.Category.Category>(category);
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Hiçbir ürün bulunamadı.";
                    result.IsSuccess = false;
                }
            }

            return result;
        }

    }

}

