using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class NewsLanguage
    {
        [Key, ForeignKey("News"), Column(Order = 1)]
        public int NewsId { get; set; }

        public News News { get; set; }

        [Key, ForeignKey("Language"), Column(Order = 2)]
        public EnumLanguage LanguageId { get; set; }

        public Language Language { get; set; }

        public string Title { get; set; }

        public string Seo_Keywords { get; set; }

        public string Seo_Description { get; set; }

        public string NewsContent { get; set; }
    }
}
