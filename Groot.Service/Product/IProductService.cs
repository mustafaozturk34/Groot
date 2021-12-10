using Groot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groot.Service.Product
{
    public interface IProductService
    {
        // ProductService clasında kullanılacak metodlar burada tanımlandı.
        public General<Model.Product.Product> Insert(Model.Product.Product newProduct);
        public General<Model.Product.Product> GetProducts();
        public General<Model.Product.Product> Update(int id, Model.Product.Product product);
        public General<Model.Product.Product> Delete(int id);

    }
}
