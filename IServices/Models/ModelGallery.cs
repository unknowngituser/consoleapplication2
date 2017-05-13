using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.IServices.Models
{
    public class ModelGallery
    {
        public ModelSeoDescription Seo { get; set; }

        public ModelAlbum Album { get; set; }

        public List<ModelAlbum> Photos { get; set; }

        public List<ModelGalleryVideo> Videos { get; set; }
    }
}
