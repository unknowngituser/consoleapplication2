using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class SeoDescription
    {
        public EnumSitePage Id { get; set; }

        public string PageName { get; set; }

        public List<SeoDescriptionLanguage> SeoDescriptionLanguage { get; set; }
    }

    public enum EnumSitePage
    {
        Index,
        About,
        Services,
        News,
        Gallery,
        Cafe
    }
}
