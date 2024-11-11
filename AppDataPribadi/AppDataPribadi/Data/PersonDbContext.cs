using AppDataPribadi.Models;
using Microsoft.EntityFrameworkCore;

namespace AppDataPribadi.Data
{
    public class PersonDbContext:DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) 
        { 
        }

        public DbSet<Person> Persons { get; set; }
    }
}
