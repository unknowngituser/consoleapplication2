using MegaKids.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.IServices.Models
{
    public class ModelSeoDescription
    {
        public EnumSitePage Id { get; set; }

        public string Title { get; set; }

        public string Keywords { get; set; }

        public string Description { get; set; }

        public string PageContent { get; set; }

        public string ExtraContent { get; set; }
    }
}
