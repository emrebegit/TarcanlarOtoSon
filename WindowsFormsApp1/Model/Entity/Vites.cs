using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model.Entity
{
    [Table("Vites")]
    public class Vites
    {
        [Key]
        public int VitesId { get; set; }
        public string VitesTuru { get; set; }
    }
}
