using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model.Entity
{
    [Table("YapilanIslem")]
    class YapilanIslem
    {
        [Key]
        public int YapilanIslemId { get; set; }
        public string YapilanIslemAciklama { get; set; }
    }
}
