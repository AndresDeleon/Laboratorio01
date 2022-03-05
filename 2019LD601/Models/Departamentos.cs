using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2019LD601.Models
{
    public class Departamentos
    {
        [Key]
        public int id { get; set; }
        public string departamento { get; set; }
    }
}
