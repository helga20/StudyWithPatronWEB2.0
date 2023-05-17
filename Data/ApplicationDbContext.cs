using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudyWithPatron.Models;

namespace StudyWithPatron.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();
        //}

        public DbSet<ScoreBombs> ScoreBomb { get; set; }

        public DbSet<ScoreUsers> ScoreUser { get; set; }

        public DbSet<Users> User { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

       
    }
}