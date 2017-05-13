using MegaKids.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.IServices.Models.WebPage
{
    public class SeoLang
    {
        public EnumSitePage Id { get; set; }

        public string Ru_Title { get; set; }

        public string Ru_Keywords { get; set; }

        public string Ru_Description { get; set; }

        public string Ru_PageContent { get; set; }

        public string Ru_ExtraContent { get; set; }

        public string Ro_Title { get; set; }

        public string Ro_Keywords { get; set; }

        public string Ro_Description { get; set; }

        public string Ro_PageContent { get; set; }

        public string Ro_ExtraContent { get; set; }
    }
}
