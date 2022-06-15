using BiblioGonza.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace BiblioGonza.DAL.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Copy> Copies { get; set; }
    }
}
