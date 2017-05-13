using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class AlbumLanguage
    {
        [Key, ForeignKey("Album"), Column(Order = 1)]
        public int AlbumId { get; set; }

        public Album Album { get; set; }

        [Key, ForeignKey("Language"), Column(Order = 2)]
        public EnumLanguage LanguageId { get; set; }

        public Language Language { get; set; }

        public string Name { get; set; }

        public string Descrition { get; set; }
    }
}
