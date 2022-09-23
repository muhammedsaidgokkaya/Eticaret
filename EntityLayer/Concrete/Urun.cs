using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string DescriptionName { get; set; }
        public string Description { get; set; }
        public string Adet { get; set; }
        public string ResimYol { get; set; }
        [NotMapped]
        public IFormFile Resim { get; set; }
        public int CategoryId { get; set; }
        public string CategoryCategoryBaslik { get; set; }
        public Category Category { get; set; }
    }
}
