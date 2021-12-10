using AutoMapper;
using Groot.DB.Entities.DataContext;
using Groot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groot.Service.Product
{
    //ürün servis katmanı
    public class ProductService : IProductService
    {
        private readonly IMapper mapper; //Mapper çağrıldı 

        public ProductService(IMapper _mapper)
        {
            mapper = _mapper;
        }


        //ürün ekleme işlemi
        public General<Model.Product.Product> Insert(Model.Product.Product newProduct)
        {
            var result = new General<Model.Product.Product>() { IsSuccess = false };

            var productModel = mapper.Map<Groot.DB.Entities.Product>(newProduct);
            using (var srv = new GrootContext())
            {
                productModel.Idate = DateTime.Now;
                srv.Product.Add(productModel);
                srv.SaveChanges();
                result.Entity = mapper.Map<Groot.Model.Product.Product>(productModel);
                result.IsSuccess = true;
            }
            


            return result;
        }


        //ürün listeleme işlemi
        public General<Model.Product.Product> GetProducts()
        {
            var result = new General<Model.Product.Product>();

            using (var context = new GrootContext())
            {
                var data = context.Product
                    .Where(x => !x.IsActive && !x.IsDeleted)
                    .OrderBy(x => x.Id);

                if (data.Any())
                {
                    result.List = mapper.Map<List<Model.Product.Product>>(data);
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Hiçbir ürün bulunamadı.";
                }
            }

            return result;
        }

        //ürün güncelleme işlemi
        public General<Model.Product.Product> Update(int id, Model.Product.Product product)
        {
            var result = new General<Model.Product.Product>();

            using (var context = new GrootContext())
            {
                var updateProduct= context.Product.SingleOrDefault(i => i.Id == id);

                if (updateProduct is not null)
                {
                    updateProduct.Name = product.Name;
                    updateProduct.DisplayName = product.DisplayName;
                    updateProduct.Description = product.Description;
                    updateProduct.Stock = product.Stock;
                    updateProduct.Price = product.Price;

                    context.SaveChanges();

                    result.Entity = mapper.Map<Model.Product.Product>(updateProduct);
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Hiçbir ürün bulunamadı.";
                }
            }

            return result;
        }

        //ürün silme işlemi
        public General<Model.Product.Product> Delete(int id)
        {
            var result = new General<Model.Product.Product>();

            using (var context = new GrootContext())
            {
                var product = context.Product.SingleOrDefault(i => i.Id == id);

                if (product is not null)
                {
                    context.Product.Remove(product);
                    context.SaveChanges();

                    result.Entity = mapper.Map<Model.Product.Product>(product);
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
