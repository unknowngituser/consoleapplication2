using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class CafeAlbumLanguage
    {
        [Key, ForeignKey("CafeAlbum"), Column(Order = 1)]
        public int CafeAlbumId { get; set; }

        public CafeAlbum CafeAlbum { get; set; }

        [Key, ForeignKey("Language"), Column(Order = 2)]
        public EnumLanguage LanguageId { get; set; }

        public Language Language { get; set; }

        public string Name { get; set; }
        
    }
}
