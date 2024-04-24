using Microsoft.EntityFrameworkCore;
using Article.Services.API.Models;

namespace Article.Services.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ArticleEntity> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArticleEntity>().HasData(new ArticleEntity
            {
                Id = 1,
                Title = "article1",
                Content = "content content content 111", 
                PublishedDate = DateTime.Now,
            });
            modelBuilder.Entity<ArticleEntity>().HasData(new ArticleEntity
            {
                Id = 2,
                Title = "article2",
                Content = "content content content 222", 
                PublishedDate = DateTime.Now,
            });
        }
    }
}
