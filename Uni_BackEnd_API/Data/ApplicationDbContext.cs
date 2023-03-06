using Microsoft.EntityFrameworkCore;
using Uni_BackEnd_API.Models;

namespace Uni_BackEnd_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<React> Reacts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<View> Views { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Comment>().HasOne(t => t.idea).WithMany(u => u.comment).HasForeignKey(u => u.ideaId).OnDelete(DeleteBehavior.Restrict);
           modelBuilder.Entity<View>().HasOne(t => t.idea).WithMany(u => u.view).HasForeignKey(u=>u.ideaId).OnDelete(DeleteBehavior.Restrict);
           modelBuilder.Entity<React>().HasOne(t => t.idea).WithMany(u => u.reacts).HasForeignKey(u => u.ideaId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
