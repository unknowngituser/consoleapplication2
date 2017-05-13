using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MegaKids.IServices.Models.WebPage
{
    public class AlbumLang
    {
        public int Id { get; set; }

        public string Ru_Title { get; set; }

        public string Ro_Title { get; set; }

        public DateTime? CreateDate { get; set; }

        public HttpPostedFileBase PhotoFile { get; set; }

        public string PhotoName { get; set; }
    }
}
