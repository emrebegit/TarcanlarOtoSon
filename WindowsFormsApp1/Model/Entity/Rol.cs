using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model.Entity
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public int RolId { get; set; }
        public string RolAdi { get; set; }
    }
}
