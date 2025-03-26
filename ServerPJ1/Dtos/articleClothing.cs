using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ServerPJ1.Dtos
{
    public class articleClothing
    {
        public int Id { get; set; }

        public string BrandName { get; set; } = null!;

        public int storeID { get; set; }

        public string Tops { get; set; } = null!;

        public string Pants { get; set; } = null!;

        public string Shoes { get; set; } = null!;

        public string Outerwear { get; set; } = null!;

        public int Quantity { get; set; } 

    }
}
