﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.IServices.Models
{
    public class ModelSlider
    {
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public string Photo { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
