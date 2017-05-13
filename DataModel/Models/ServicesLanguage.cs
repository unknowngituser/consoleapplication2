using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class ServicesLanguage
    {
        [Key, ForeignKey("Services"), Column(Order = 1)]
        public int ServicesId { get; set; }

        public Services Services { get; set; }

        [Key, ForeignKey("Language"), Column(Order = 2)]
        public EnumLanguage LanguageId { get; set; }

        public Language Language { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
