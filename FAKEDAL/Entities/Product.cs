using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeDAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string? Description { get; set; }
        public int Quantite { get; set; }
        public double Prix { get; set; }
        public bool InStock { get; set; }

    }
}
