using BookstoreAPI.Models;
using BookstoreAPI.Models.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAPI.Data
{
    public class Bookstorecontext : IdentityDbContext<ApplicationUser>
    {
        public Bookstorecontext(DbContextOptions<Bookstorecontext> options) : base(options) 
        { 
        }
        public virtual DbSet<Book> Books { get; set; }
        
    }
}
