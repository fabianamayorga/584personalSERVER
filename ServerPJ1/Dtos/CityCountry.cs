using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ServerPJ1.Dtos
{
    public class CityCountry
    {
        public int Id { get; set; }
       
        public string Name { get; set; } = null!;

        public int Population { get; set; }

        public string CountryName { get; set; } = null!;
    }
}
