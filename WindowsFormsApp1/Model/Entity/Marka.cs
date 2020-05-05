using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model.Entity
{
    [Table("Marka")]
    public class Marka
    {
        [Key]
        public int MarkaId { get; set; }
        public string MarkaAdi { get; set; }
    }
}
