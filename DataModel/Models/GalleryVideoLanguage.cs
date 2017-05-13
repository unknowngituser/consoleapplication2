using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class GalleryVideoLanguage
    {
        [Key, ForeignKey("GalleryVideo"), Column(Order = 1)]
        public int GalleryVideoId { get; set; }

        public GalleryVideo GalleryVideo { get; set; }

        [Key, ForeignKey("Language"), Column(Order = 2)]
        public EnumLanguage LanguageId { get; set; }

        public Language Language { get; set; }

        public string Title { get; set; }

        public string Video { get; set; }
    }
}
