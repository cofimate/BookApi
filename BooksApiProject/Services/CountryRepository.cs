using BooksApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BooksApiProject.Services
{
    public class CountryRepository : ICountryRepository
    {
        private BookDbContext countryContext;
        public CountryRepository(BookDbContext _countryContext)
        {
            countryContext = _countryContext;
        }

        public bool CountryExists(int countryId)
        {
            return countryContext.Countries.Any(c => c.Id == countryId);
        }

        public ICollection<Author> GetAuthorsFromCountry(int countryId)
        {
            return countryContext.Authors.Where(c => c.Country.Id == countryId).ToList();
        }

        public ICollection<Country> GetCountries()
        {
            return countryContext.Countries.OrderBy(c => c.Name).ToList();
        }

        public Country GetCountry(int countryId)
        {
            return countryContext.Countries.Where( c => c.Id == countryId).FirstOrDefault();
        }

        public Country GetCountryOfAuther(int authorId)
        {
            return countryContext.Authors.Where(a => a.Id == authorId).Select(c => c.Country).FirstOrDefault();
        }

        public bool IsDuplicatedCountry(int countryId, string countryName)
        {
            var country = countryContext.Countries.Where(c => c.Name.Trim().ToLower() == countryName.Trim().ToLower()
                                        && c.Id != countryId).FirstOrDefault();

             return (country == null ) ? false : true;
        }
        public bool CreateCountry(Country country)
        {
            countryContext.AddAsync(country);
            return Save();
        }
        public bool UpdateCountry(Country country)
        {
            countryContext.Update(country);
            return Save();

        }
        public bool DeleteCountry(Country country)
        {
            countryContext.Remove(country);
            return Save();

        }
        public bool Save()
        {
            var saved = countryContext.SaveChanges();
            return (saved >= 0);
        }
    }
}
