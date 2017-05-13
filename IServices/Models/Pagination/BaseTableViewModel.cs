using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.IServices.Models.Pagination
{
    public class BaseTableViewModel<T>
    {
        public BaseTableViewModel()
        {
            List = new List<T>();
        }
        public List<T> List { get; set; }
        public int CountPage { get; set; }
        public int CountItems { get; set; }
        public decimal Amount { get; set; }
    }
}
