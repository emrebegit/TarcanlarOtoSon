using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model.Entity
{
    [Table("Yakit")]
    public class Yakit
    {
        [Key]
        public int YakitId { get; set; }
        public string YakitTuru { get; set; }
    }
}
