using MegaKids.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Содержит сущности и логику предметной области;  создает хранилище с помощью инфраструктуры Entity Framework
/// </summary>
namespace MegaKids.DataModel
{
    public class DataContext : DbContext
    {
        public DataContext()
        : base("DefaultConnection")
        { }

        public DbSet<News> News { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<NewsLanguage> NewsLanguages { get; set; }

        public DbSet<AlbumLanguage> AlbumLanguages { get; set; }

        public DbSet<Services> Services { get; set; }

        public DbSet<ServicesLanguage> ServicesLanguages { get; set; }

        public DbSet<SeoDescription> SeoDescriptions { get; set; }

        public DbSet<SeoDescriptionLanguage> SeoDescriptionLanguages { get; set; }

        public DbSet<GalleryVideo> GalleryVideos { get; set; }

        public DbSet<GalleryVideoLanguage> GalleryVideoLanguages { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<SliderLanguage> SliderLanguages { get; set; }

        public DbSet<CafeAlbum> CafeAlbums { get; set; }

        public DbSet<CafeAlbumLanguage> CafeAlbumLanguages { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            mb.Entity<User>().
                Property(p => p.RegistrationDate)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();
            mb.Entity<User>().
                Property(p => p.LastLoginDate)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();
        }
    }
}
