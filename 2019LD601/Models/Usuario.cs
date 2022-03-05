using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2019LD601.Models
{
    public class Usuario
    {
        [Key]

        public int idUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int departamentoId { get; set; }
        public string Clave { get; set; }
        public string Estado { get; set; }
    }
}
