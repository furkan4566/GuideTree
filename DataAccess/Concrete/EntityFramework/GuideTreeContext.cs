using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class GuideTreeContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SoftwareLangue> SoftwareLangues { get; set; }
        public DbSet<SoftwareBranch> SoftwareBranches { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GuideTree;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api ile articleCategory'nin birincil anahtarlarını belirtirlir
            modelBuilder.Entity<ArticleCategory>().HasKey(c => new { c.CategoryId, c.ArticleId });
        }
    }
}
