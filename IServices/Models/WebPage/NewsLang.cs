using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MegaKids.IServices.Models.WebPage
{
    public class NewsLang
    {
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public HttpPostedFileBase PhotoFile { get; set; }

        public string Photo { get; set; }

        public string Ru_Title { get; set; }

        public string Ru_Seo_Keywords { get; set; }

        public string Ru_Seo_Description { get; set; }

        public string Ru_NewsContent { get; set; }

        public string Ru_PreviewContent { get; set; }

        public string Ro_Title { get; set; }

        public string Ro_Seo_Keywords { get; set; }

        public string Ro_Seo_Description { get; set; }

        public string Ro_NewsContent { get; set; }

        public string Ro_PreviewContent { get; set; }
    }
}
