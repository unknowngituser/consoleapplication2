using MegaKids.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.IServices.Models
{
    public class ModelCafeAlbum
    {
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public ModelCafeAlbum Parent { get; set; }

        public List<ModelCafeAlbum> ChildPhotos { get; set; }

        public string PhotoName { get; set; }

    }
}