using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2019LD601.Models
{
    public class RolesporUsuario
    {
        [Key]

        public int IdRolporUsuario { get; set; }
        public int idRol { get; set; }
        public int idUsuario { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime Fechamodificacion{ get; set; }
    }
}
