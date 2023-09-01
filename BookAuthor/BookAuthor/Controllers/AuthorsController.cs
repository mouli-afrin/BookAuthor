using BookAuthor.Db;
using BookAuthor.Models;
using BookAuthor.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookAuthor.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AuthorDbContext authorDbContext;

        public AuthorsController(AuthorDbContext authorDbContext)
        {
            this.authorDbContext = authorDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> AuthorList()
        {
            var authors = await authorDbContext.Authors.ToListAsync();
            return View(authors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel createAuthorRequest)
        {
            var author = new Author()
            {
               Id = Guid.NewGuid(),
               Author_Name= createAuthorRequest.Author_Name,
               Book_Name= createAuthorRequest.Book_Name,
               Email= createAuthorRequest.Email
            };

            await authorDbContext.Authors.AddAsync(author);
            await authorDbContext.SaveChangesAsync();
            return RedirectToAction("AuthorList");
        }
    }
}
