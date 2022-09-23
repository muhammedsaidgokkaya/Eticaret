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
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryBaslik { get; set; }
        public int? ParentId { get; set; }
        public List<Urun> Uruns { get; set; }
    }
}
