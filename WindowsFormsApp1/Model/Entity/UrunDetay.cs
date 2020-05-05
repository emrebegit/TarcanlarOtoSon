using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model.Entity
{
    public class UrunDetay
    {
        [Key]
        public int UrunDetayId { get; set; }
        public string UrunMarka { get; set; }
        public string  UrunModel { get; set; }
        public DateTime UrunUretimTarihi { get; set; }
    }
}
