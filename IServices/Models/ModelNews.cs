using MegaKids.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.IServices.Models
{
    public class ModelNews
    {
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public Language Language { get; set; }

        public string Photo { get; set; }

        public string Title { get; set; }

        public string Seo_Keywords { get; set; }

        public string Seo_Description { get; set; }

        public string NewsContent { get; set; }

        public string PreviewContent { get; set; }
    }
}
