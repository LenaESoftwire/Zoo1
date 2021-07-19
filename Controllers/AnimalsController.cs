using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using zoo.Repositories;

namespace zoo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly ILogger<AnimalsController> _logger;
        private readonly IAnimalsRepo _animals;

        public AnimalsController(ILogger<AnimalsController> logger, IAnimalsRepo animals)
        {
            _logger = logger;
            _animals = animals;
        }

        [HttpGet]
        public IActionResult AnimalsList()
        {

            var booksInDb = _bookService.GetBooks();
            var books = boo)
    {
        _bookService = bookService;
    }

    [HttpGet("/[controller]/{id}")]
    public IActionResult Book(int id)
    {
        var book = _bookService.GetBookById(id);
        return View(new BookViewModel(book));
    }

    [HttpGet]
    public IActionResult Catalogue()
    {

        var booksInDb = _bookService.GetBooks();
        var books = booksInDb.Select(book => new BookViewModel(book)).ToList();
        var catalogue = new CatalogueViewModel
        {
            Books = books
        };
        return View(catalogue);
    }
