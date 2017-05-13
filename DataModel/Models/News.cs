using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class News
    {
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public string Photo { get; set; }

        public List<NewsLanguage> NewsLanguage { get; set; }
    }
}
