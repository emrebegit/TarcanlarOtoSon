using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model.Entity
{
    [Table("Arac")]
    public class Arac
    {
        [Key]
        public int AracSaseNo { get; set; }
        public int MarkaId { get; set; }
        public int ModelId { get; set; }
        public int YakitId { get; set; }
        public int VitesId { get; set; }
        public string AracYil { get; set; }
        public string AracKm { get; set; }
        public string AracRenk { get; set; }
    }
}
