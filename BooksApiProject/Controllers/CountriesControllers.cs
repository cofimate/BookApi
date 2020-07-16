using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooksApiProject.Services;
using BooksApiProject.Dtos;
using BooksApiProject.Models;

namespace BooksApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        //api/Countries
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDto>))]
        public IActionResult GetCountries()
        {
            var countries = _countryRepository.GetCountries().ToList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countriesDTO = new List<CountryDto>();
            foreach (var country in countries)
            {
                countriesDTO.Add(new CountryDto
                {
                    Id = country.Id,
                    Name = country.Name
                });
            }
            return Ok(countriesDTO);
        }

        //api/Countries/countryId
        [HttpGet("{countryId}", Name="GetCountry")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDto>))]
        public IActionResult GetCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId))
                return NotFound();

            var country = _countryRepository.GetCountry(countryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryDTO = new CountryDto()
            {
                Id = country.Id,
                Name = country.Name
            };
            return Ok(countryDTO);
        }

        //api/countries/create/Id
        [HttpPost]
        [ProducesResponseType(201, Type=typeof(Country))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult CreateCountry([FromBody]Country countryToCreate)
        {
            if (countryToCreate == null)
                return BadRequest(ModelState);

            var country = _countryRepository.GetCountries().Where(c => c.Name.Trim().ToLower() == countryToCreate.Name.Trim().ToLower()).FirstOrDefault();

            if (country != null)
            {
                ModelState.AddModelError("", $"Country {countryToCreate.Name} already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_countryRepository.CreateCountry(countryToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong saveing {countryToCreate.Name}");
                return StatusCode(500, ModelState);

            }
            return CreatedAtRoute("GetCountry", new { countryId = countryToCreate.Id }, countryToCreate);
        }


        //api/countries/create/Id
        [HttpDelete("{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult DeleteCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId))
                return NotFound();

            var country = _countryRepository.GetCountry(countryId);

            if ( _countryRepository.GetAuthorsFromCountry(countryId).Count()> 0 )
            {
                ModelState.AddModelError("", $"Country {country.Name} can not be deleted bacause it is used author");
                return StatusCode(409, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_countryRepository.DeleteCountry(country))
            {
                ModelState.AddModelError("", $"Something went wrong deleting {country.Name}");
                return StatusCode(500, ModelState);

            }
            return NoContent();
        }

        //api/countries/Id
        [HttpPut("{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult UpdateCountry(int countryId, [FromBody]Country countryToUpdate)
        {
            if (countryToUpdate == null)
                return BadRequest(ModelState);

            //var country = _countryRepository.GetCountries().Where(c => c.Name.Trim().ToLower() == countryToCreate.Name.Trim().ToLower()).FirstOrDefault();

            if ( countryId != countryToUpdate.Id)
                return BadRequest(ModelState);

            if (!_countryRepository.CountryExists(countryId))
                return NotFound();

            if (_countryRepository.IsDuplicatedCountry(countryId, countryToUpdate.Name))
            {
                ModelState.AddModelError("", $"Country {countryToUpdate.Name} already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (!_countryRepository.UpdateCountry(countryToUpdate))
            {
                ModelState.AddModelError("", $"Something went wrong updating {countryToUpdate.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //api/countries/authors/authorId
        [HttpGet("authors/{authorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDto>))]
        public IActionResult GetCountrOfAuthor(int authorId)
        {
            //TO DO validate author exists

            var country = _countryRepository.GetCountryOfAuther(authorId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryDTO = new CountryDto()
            {
                Id = country.Id,
                Name = country.Name
            };
            return Ok(countryDTO);
        }

        //To GetAuthors from a country
    }
}
