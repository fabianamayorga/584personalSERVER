using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServerPJ1.Dtos
{
    public class brandName
    {
        public int Id { get; set; } 

        public string BrandName { get; set; } = null!;

        public string Location { get; set; } = null!;


    }
}
