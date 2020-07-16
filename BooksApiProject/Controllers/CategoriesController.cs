using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BooksApiProject.Services;
using BooksApiProject.Dtos;

namespace BooksApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICathegoryRepository categoryRepository;
        public CategoriesController(ICathegoryRepository _cathegoryRepository)
        {
            categoryRepository = _cathegoryRepository;
        }

        //api/Countries
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetCategories()
        {
            var categories= categoryRepository.GetCategories();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoriesDTO = new List<CategoryDto>();
            
            foreach (var category in categories)
            {
                categoriesDTO.Add(new CategoryDto
                { 
                    Id = category.Id,
                    Name = category.Name
                });
            }
            return Ok(categoriesDTO);
        }


        [HttpGet]
        [HttpGet("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetCategory(int categoryId)
        {
            if (!categoryRepository.CathegoryExists(categoryId))
                return NotFound();

            var category = categoryRepository.GetCategory(categoryId);

            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }

            var categoryDto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };
            return Ok(categoryDto);
        }

        //api/categories/books/booksId
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDto>))]
        public IActionResult GetCategoriesFromBook(int bookId)
        {


            var categories = categoryRepository.GetCathegoriesOfABook(bookId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoriesDto = new List<CategoryDto>();

            foreach (var category in categories)
            {
                categoriesDto.Add(new CategoryDto()
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            return Ok(categoriesDto);
        }

        //To Do Get all Books from GetCategories
    }
}