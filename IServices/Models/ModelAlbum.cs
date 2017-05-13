using MegaKids.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.IServices.Models
{
    public class ModelAlbum
    {
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public string Name { get; set; }

        public string Descrition { get; set; }

        public int? ParentId { get; set; }

        public Album Parent { get; set; }

        public List<Album> ChildPhotos { get; set; }

        public string PhotoName { get; set; }
                
    }
}
