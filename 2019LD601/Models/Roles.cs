using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2019LD601.Models
{
    public class Roles
    {
        [Key]

        public int idRol { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
    }
}
