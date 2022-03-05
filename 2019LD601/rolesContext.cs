using _2019LD601.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2019LD601
{
    public class rolesContext : DbContext
    {
        public rolesContext(DbContextOptions<rolesContext> options) : base(options)
        {

        }

        public DbSet<Departamentos> departamentos { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<RolesporUsuario> rolesporusuarios { get; set; }
        public DbSet<Usuario> usuario { get; set; }
    }
}
