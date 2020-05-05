using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model.Entity
{
    [Table("Model")]
    class Model
    {
        [Key]
        public int ModelId { get; set; }
        public int MarkaId { get; set; }
        public string ModelAdi { get; set; }
    }
}
