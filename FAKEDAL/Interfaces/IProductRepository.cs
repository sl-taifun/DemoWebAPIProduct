using FakeDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeDAL.Interfaces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public Product? GetById(int id);
        public Product Add(Product trainer);

        public IEnumerable<Product> GetByMinPrice(double price);

        public IEnumerable<Product> GetByInStock(bool inStock);
    }
}
