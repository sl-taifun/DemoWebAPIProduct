using FakeDAL.Entities;
using FakeDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeDAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Nom = "Clavier mécanique", Description = "Clavier RGB avec switches rouges", Quantite = 12, Prix = 79.99, InStock = true },
            new Product { Id = 2, Nom = "Souris sans fil", Description = "Souris ergonomique 2.4GHz", Quantite = 0, Prix = 29.99, InStock = false },
            new Product { Id = 3, Nom = "Écran 24 pouces", Description = "Écran IPS Full HD", Quantite = 5, Prix = 149.99, InStock = true },
            new Product { Id = 4, Nom = "Casque audio", Description = "Casque Bluetooth à réduction de bruit", Quantite = 3, Prix = 89.50, InStock = true },
            new Product { Id = 5, Nom = "Webcam HD", Description = "Caméra 1080p avec micro", Quantite = 0, Prix = 49.90, InStock = false },
            new Product { Id = 6, Nom = "Tapis de souris", Description = "Tapis XXL antidérapant", Quantite = 20, Prix = 19.99, InStock = true },
            new Product { Id = 7, Nom = "Disque dur externe", Description = "1To USB 3.0", Quantite = 7, Prix = 64.99, InStock = true },
            new Product { Id = 8, Nom = "Clé USB", Description = "64Go USB 3.1", Quantite = 15, Prix = 14.99, InStock = true },
            new Product { Id = 9, Nom = "Station d'accueil", Description = "Dock USB-C avec HDMI et Ethernet", Quantite = 2, Prix = 109.00, InStock = true },
            new Product { Id = 10, Nom = "Support pour ordinateur", Description = "Réglable en aluminium", Quantite = 0, Prix = 39.99, InStock = false },
        };

        private static int _nextId = 0;
        public Product Add(Product product)
        {
            product.Id = ++_nextId;
            _products.Add(product);
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product? GetById(int id)
        {
            return _products.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Product> GetByMinPrice(double price)
        {
            return _products.Where(p => p.Prix >= price);
        }

        public IEnumerable<Product> GetByInStock(bool inStock)
        {
            return _products.Where(p => p.InStock == inStock);
        }
    }
}
