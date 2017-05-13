using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.DataModel.Models
{
    public class CafeAlbum
    {
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? ParentId { get; set; }

        public CafeAlbum Parent { get; set; }

        public List<CafeAlbum> ChildPhotos { get; set; }

        public string PhotoName { get; set; }

        public List<CafeAlbumLanguage> CafeAlbumLanguage { get; set; }
    }
}
