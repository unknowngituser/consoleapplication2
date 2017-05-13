using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class GalleryVideo
    {
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public List<SliderLanguage> SliderLanguage { get; set; }
    }
}
