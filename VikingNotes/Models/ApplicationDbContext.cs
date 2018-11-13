using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VikingNotes.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Quiz> Guizzes { get; set; } // step 3c
        public DbSet<Genre> Genres { get; set; } // step 4
        public DbSet<Attendance> Attendances { get; set; } 



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

            modelBuilder.Entity<Attendance>()
                .HasRequired(a =>a.Quiz)
                .WithMany()
                .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }
    }
}