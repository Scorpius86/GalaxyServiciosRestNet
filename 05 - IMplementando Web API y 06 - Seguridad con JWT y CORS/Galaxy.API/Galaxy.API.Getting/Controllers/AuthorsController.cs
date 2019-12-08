using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Galaxy.API.Data.Services;
using Galaxy.API.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Galaxy.API.Data.Helpers;

namespace Galaxy.API.Getting.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private ILibraryRepository _libraryRepository;

        public AuthorsController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _libraryRepository.GetAuthors();
            /*
            List<AuthorDto> authorDtos = new List<AuthorDto>();
            authorsFromRepo.ToList().ForEach(author =>
            {
                AuthorDto authorDto = new AuthorDto();
                authorDto.Name = author.FirstName + " " + author.LastName;
                authorDto.Genre = author.Genre;

                authorDtos.Add(authorDto);
            }); 
            return Ok(authorDtos); 
            */
            //throw new Exception("Mi error");
            var authors = Mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(Guid id)
        {
            var authorFromRepo = _libraryRepository.GetAuthor(id);

            if (authorFromRepo == null)
            {
                return NoContent();
            }

            var author = Mapper.Map<AuthorDto>(authorFromRepo);
            return Ok(author);
        }
    }
}