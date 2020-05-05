using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model.Entity
{
    [Table("Durum")]
    public class Durum
    {
        [Key]
        public int DurumId { get; set; }
        public string Aciklama { get; set; }
    }
}
