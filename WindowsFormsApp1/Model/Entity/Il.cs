using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model.Entity
{
    [Table("Il")]
    public class Il
    {
        [Key]
        public int Ilid { get; set; }
        public string IlAdi { get; set; }
    }
}
