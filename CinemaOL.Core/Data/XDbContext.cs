


using Microsoft.EntityFrameworkCore;

namespace CinemaOL.Data
{
    public class XDbContext
    {
        public XDbContext()
        {

        }
        protected internal virtual void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.UseSqlite("Filename=./Blogging.db");
        }

        protected internal virtual void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }

}