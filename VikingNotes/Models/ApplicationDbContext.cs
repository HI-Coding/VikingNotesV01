using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VikingNotes.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Quiz> Guizzes { get; set; } // step 3c
        public DbSet<Genre> Genres { get; set; } // step 4
        public DbSet<Relationship> Relationships { get; set; } 
      
        


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u =>u.Followers)
                .WithRequired(f =>f.Followee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followees)
                .WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }
    }
}