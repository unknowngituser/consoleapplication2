using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class SliderLanguage
    {
        [Key, ForeignKey("Slider"), Column(Order = 1)]
        public int SliderId { get; set; }

        public Slider Slider { get; set; }

        [Key, ForeignKey("Language"), Column(Order = 2)]
        public EnumLanguage LanguageId { get; set; }

        public Language Language { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
