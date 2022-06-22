using LibraryApp.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
        {}

        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BooksCopies { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
