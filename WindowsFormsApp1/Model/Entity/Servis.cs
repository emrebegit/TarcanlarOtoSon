using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model.Entity
{
    [Table("Servis")]
    public class Servis
    {
        [Key]
        public int ServisKayitNo { get; set; }
        [StringLength(17)]
        public string AracSaseNo { get; set; }
        public int CariId { get; set; }
        public int DurumId { get; set; }
        public int CalisanNo { get; set; }
        [Column(TypeName ="smalldatetime")]
        public DateTime GirisTarihi { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CikisTarihi { get; set; }
    }
}
