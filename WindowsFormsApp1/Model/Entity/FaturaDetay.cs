using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model.Entity
{
    [Table("FaturaDetay")]
    class FaturaDetay
    {
        [Key]
        public int ID { get; set; }
        public int ServisKayitNo { get; set; }
        public int FaturaId { get; set; }
        public int FaturaTipNo { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal BirimFiyat { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FaturaTarihi { get; set; }
    }
}
