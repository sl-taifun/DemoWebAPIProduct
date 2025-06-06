using FakeDAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string? Description { get; set; }
        public int Quantite { get; set; }
        public double Prix { get; set; }
        public bool InStock { get; set; }

        public ProductDTO(Product entity)
        {
            Id = entity.Id;
            Nom = entity.Nom;
            Description = entity.Description;
            Quantite = entity.Quantite;
            Prix = entity.Prix;
            InStock = entity.InStock;
        }
    }

    public class CreateProductDTO
    {
        [Required(ErrorMessage = "Le nom est requis")]
        [MaxLength(150, ErrorMessage = "Le nom ne peut pas dépasser 150 caractères")]
        public string Nom { get; set; }

        [MaxLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
        public string? Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La quantité doit être strictement positive")] // quantité > 0 obligatoire
        public int Quantite { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Le prix doit être positif")]
        public double Prix { get; set; }

        public static Product ToEntity(CreateProductDTO dto)
        {
            return new Product
            {
                Id = 0,
                Nom = dto.Nom,
                Description = dto.Description,
                Quantite = dto.Quantite,
                Prix = dto.Prix,
                InStock = true // toujours à true à la création
            };
        }
    }



    public class ProductListDTO
    {
        public int Count { get; set; }
        public double TotalPrice { get; set; }
        public IEnumerable<ProductSummaryDTO> Products { get; set; }
    }

    public class ProductSummaryDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public double Prix { get; set; }

        public ProductSummaryDTO(Product product)
        {
            Id = product.Id;
            Nom = product.Nom;
            Quantite = product.Quantite;
            Prix = product.Prix;
        }
    }

    //public class UpdateProductDTO
    //{
    //    [Required(ErrorMessage = "Le nom est requis")]
    //    [MaxLength(150, ErrorMessage = "Le nom ne peut pas dépasser 150 caractères")]
    //    public string Nom { get; set; }

    //    [MaxLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
    //    public string? Description { get; set; }

    //    [Range(0, int.MaxValue, ErrorMessage = "La quantité doit être positive")]
    //    public int Quantite { get; set; }

    //    [Range(0.0, double.MaxValue, ErrorMessage = "Le prix doit être positif")]
    //    public double Prix { get; set; }

    //    public bool InStock { get; set; }

    //    public static Product ToEntity(UpdateProductDTO dto)
    //    {
    //        return new Product
    //        {
    //            Nom = dto.Nom,
    //            Description = dto.Description,
    //            Quantite = dto.Quantite,
    //            Prix = dto.Prix,
    //            InStock = dto.InStock
    //        };
    //    }
    //}


}
