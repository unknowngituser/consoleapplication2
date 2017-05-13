using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class SeoDescriptionLanguage
    {
        [Key, ForeignKey("SeoDescription"), Column(Order = 1)]
        public EnumSitePage SeoDescriptionId { get; set; }

        public SeoDescription SeoDescription { get; set; }

        [Key, ForeignKey("Language"), Column(Order = 2)]
        public EnumLanguage LanguageId { get; set; }

        public Language Language { get; set; }

        public string Title { get; set; }

        public string Keywords { get; set; }

        public string Description { get; set; }

        public string PageContent { get; set; }

        public string ExtraContent { get; set; }
    }
}
