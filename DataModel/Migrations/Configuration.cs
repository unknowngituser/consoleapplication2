using MegaKids.DataModel.Models;

namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MegaKids.DataModel.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MegaKids.DataModel.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            // Инициализация языков
            context.Languages.AddOrUpdate(
              p => p.Id,
              new Language { Id = EnumLanguage.ru, Code = "ru", Name = "Русский"},
              new Language { Id = EnumLanguage.ro, Code = "ro", Name = "Румынский" }
            );
            // Инициализация ролей пользователей
            context.Roles.AddOrUpdate(
                p => p.Id,
                new Role { Id = TypeRoles.Admin, Name = "Администратор" },
                new Role { Id = TypeRoles.Moderator, Name = "Модератор" },
                new Role { Id = TypeRoles.User, Name = "Пользователь" }
            );
            // Инициализация SEO Description
            context.SeoDescriptions.AddOrUpdate(
                p => p.Id,
                new SeoDescription { Id = EnumSitePage.Index, PageName = "Главная"},
                new SeoDescription { Id = EnumSitePage.About, PageName = "О нас" },
                new SeoDescription { Id = EnumSitePage.Services, PageName = "Услуги" },
                new SeoDescription { Id = EnumSitePage.News, PageName = "Новости" },
                new SeoDescription { Id = EnumSitePage.Gallery, PageName = "Галерея" },
                new SeoDescription { Id = EnumSitePage.Cafe, PageName = "Кафе" }
            );
            context.SeoDescriptionLanguages.AddOrUpdate(
                p => p.SeoDescriptionId,
                new SeoDescriptionLanguage { SeoDescriptionId = EnumSitePage.Index, LanguageId = EnumLanguage.ru },
                new SeoDescriptionLanguage { SeoDescriptionId = EnumSitePage.Index, LanguageId = EnumLanguage.ro },
                new SeoDescriptionLanguage { SeoDescriptionId = EnumSitePage.About, LanguageId = EnumLanguage.ru },
                new SeoDescriptionLanguage { SeoDescriptionId = EnumSitePage.About, LanguageId = EnumLanguage.ro },
                new SeoDescriptionLanguage { SeoDescriptionId = EnumSitePage.Services, LanguageId = EnumLanguage.ru },
                new SeoDescriptionLanguage { SeoDescriptionId = EnumSitePage.Services, LanguageId = EnumLanguage.ro },
                new SeoDescriptionLanguage { SeoDescriptionId = EnumSitePage.News, LanguageId = EnumLanguage.ru },
                new SeoDescriptionLanguage { SeoDescriptionId = EnumSitePage.News, LanguageId = EnumLanguage.ro },
                new SeoDescriptionLanguage { SeoDescriptionId = EnumSitePage.Gallery, LanguageId = EnumLanguage.ru },
                new SeoDescriptionLanguage { SeoDescriptionId = EnumSitePage.Gallery, LanguageId = EnumLanguage.ro },
                new SeoDescriptionLanguage { SeoDescriptionId = EnumSitePage.Cafe, LanguageId = EnumLanguage.ru },
                new SeoDescriptionLanguage { SeoDescriptionId = EnumSitePage.Cafe, LanguageId = EnumLanguage.ro }
            );
        }
    }
}
