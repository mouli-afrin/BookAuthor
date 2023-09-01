using BookAuthor.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace BookAuthor.Db
{
    public class AuthorDbContext:DbContext
    {
        public AuthorDbContext(DbContextOptions<AuthorDbContext> options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
    }
}
