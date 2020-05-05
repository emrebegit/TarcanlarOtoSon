using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model.Entity
{
    [Table("FaturaFis")]
    public class FaturaFis
    {
        [Key]
        public int faturaID { get; set; }
        public int faturatipNo { get; set; }
        public DateTime faturaTarihi { get; set; }
        public int toplamTutar { get; set; }
    }
}
