using AutoMapper;
using Groot.DB.Entities;
using Groot.Model;
using Groot.Service.Category;
using Groot.Service.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Groot.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoryController(ICategoryService _categoryService, IMapper _mapper)
        {
            categoryService = _categoryService;
            mapper = _mapper;
        }
        [HttpPost]
        public General<Model.Category.Category> Insert([FromBody] Groot.Model.Category.Category newCategory)
        {
            var result = false;
            return categoryService.Insert(newCategory);
        }


        [HttpGet]
        public General<Model.Category.Category> GetCategory()
        {
            return categoryService.GetCategory();
        }

        [HttpPut("{id}")]
        public General<Model.Category.Category> Update(int id, Model.Category.Category category)
        {
            return categoryService.Update(id, category);
        }

        [HttpDelete]
        public General<Model.Category.Category> Delete(int id)
        {
            return categoryService.Delete(id);
        }




    }
}
