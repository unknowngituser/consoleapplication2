using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class Services
    {
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public string Photo { get; set; }

        public List<ServicesLanguage> ServicesLanguage { get; set; }
    }
}
