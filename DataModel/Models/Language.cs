using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class Language
    {
        [Key]
        public EnumLanguage Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public List<NewsLanguage> NewsLanguage { get; set; }

        public List<AlbumLanguage> AlbumLanguage { get; set; }
    }

    public enum EnumLanguage
    {
        [Description("Русский")]
        ru = 1,
        [Description("Румынский")]
        ro = 2
    }
}
