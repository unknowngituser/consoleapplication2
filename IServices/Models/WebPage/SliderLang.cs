using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MegaKids.IServices.Models.WebPage
{
    public class SliderLang
    {
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public HttpPostedFileBase PhotoFile { get; set; }

        public string Photo { get; set; }

        public string Ru_Title { get; set; }

        public string Ru_Content { get; set; }

        public string Ro_Title { get; set; }

        public string Ro_Content { get; set; }
    }
}
