﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Footer
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Description { get; set; }
        public string KayitOlBaslik { get; set; }
        public string KayitOlDescription { get; set; }
    }
}
