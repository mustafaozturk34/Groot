using AutoMapper;
using Groot.DB.Entities;
using Groot.Model;
using Groot.Service.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Groot.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService _productService, IMapper _mapper)
        {
            productService = _productService;
            mapper = _mapper;
        }
        [HttpPost]
        public General<Model.Product.Product> Insert([FromBody] Groot.Model.Product.Product newProduct)
        {
            var result = false;
            return productService.Insert(newProduct);
        }


        [HttpGet]
        public General<Model.Product.Product> GetProducts()
        {
            return productService.GetProducts();
        }

        [HttpPut("{id}")]
        public General<Model.Product.Product> Update(int id, Model.Product.Product product)
        {
            return productService.Update(id, product);
        }

        [HttpDelete]
        public General<Model.Product.Product> Delete(int id)
        {
            return productService.Delete(id);
        }

    }
}
