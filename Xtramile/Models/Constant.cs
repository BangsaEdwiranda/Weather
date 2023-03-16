using System.Collections.Generic;

namespace Xtramile.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
    }

    public class Constant
    {
        public static List<Country> GetListOfCountries()
        {
            var list = new List<Country>() {
                new Country() { Id = 1, Name = "England"},
                new Country() { Id = 2, Name = "Indonesia"},
                new Country() { Id = 3, Name = "Singapore"},
                new Country() { Id = 4, Name = "Malaysia"},
                new Country() { Id = 5, Name = "Australia"}
                };

            return list;
        }

        public static List<City> GetListOfCities()
        {
            var list = new List<City>() {
                new City() { Id = 1, CountryId = 1, Name = "Manchester"},
                new City() { Id = 2, CountryId = 1, Name = "Liverpool"},
                new City() { Id = 3, CountryId = 1, Name = "Birmingham"},
                new City() { Id = 4, CountryId = 2, Name = "Jakarta"},
                new City() { Id = 5, CountryId = 2, Name = "Bali"},
                new City() { Id = 6, CountryId = 2, Name = "Bandung"},
                new City() { Id = 7, CountryId = 3, Name = "Paya Lebar"},
                new City() { Id = 8, CountryId = 3, Name = "Seletar"},
                new City() { Id = 9, CountryId = 3, Name = "Newton"},
                new City() { Id = 10, CountryId = 4, Name = "Pulau Pinang"},
                new City() { Id = 11, CountryId = 4, Name = "Ipoh"},
                new City() { Id = 12, CountryId = 4, Name = "Miri"},
                new City() { Id = 13, CountryId = 5, Name = "Sydney"},
                new City() { Id = 14, CountryId = 5, Name = "Melbourne"},
                new City() { Id = 15, CountryId = 5, Name = "Canberra"},
                };

            return list;
        }
    }
}
