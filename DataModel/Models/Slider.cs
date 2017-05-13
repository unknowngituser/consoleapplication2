using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class Slider
    {
        public int Id { get; set; }

        public EnumSitePage PageId { get; set; }

        public string Photo { get; set; }

        public DateTime? CreateDate { get; set; }

        public List<SliderLanguage> SliderLanguage { get; set; }
    }
}
