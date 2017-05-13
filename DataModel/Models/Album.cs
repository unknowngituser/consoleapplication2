using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class Album
    {
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? ParentId { get; set; }

        public Album Parent { get; set; }     

        public List<Album> ChildPhotos { get; set; }

        public string PhotoName { get; set; }

        public List<AlbumLanguage> AlbumLanguage { get; set; }
    }
}
