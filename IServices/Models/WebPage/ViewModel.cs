using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.IServices.Models.WebPage
{
    public class ViewModel
    {
        public ModelSeoDescription Seo { get; set; }

        public List<ModelNews> ModelNews { get; set; }

        public List<ModelServices> ModelServices { get; set; }

        public List<ModelCafeAlbum> ModelCafeAlbum { get; set; }
    }
}
