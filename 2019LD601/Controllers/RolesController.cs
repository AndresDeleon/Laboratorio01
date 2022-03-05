using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using _2019LD601.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace _2019LD601.Controllers
{
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly rolesContext _contexto;

        public RolesController(rolesContext miContexto)
        {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/roles")]
        public IActionResult Get()
        {
            IEnumerable<Roles> rolesList = from r in _contexto.roles
                                                     select r;

            if (rolesList.Count() > 0)
            {
                return Ok(rolesList);
            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/roles/{idRol}")]
        public IActionResult Get(int idRol)
        {
            IEnumerable<Roles> roles = from r in _contexto.roles
                                                       where r.idRol == idRol
                                                       select r;


            if (roles.Count() > 0)
            {
                return Ok(roles);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/roles")]
        public IActionResult guardarRol([FromBody] Roles rolNuevo)
        {
            try
            {
                _contexto.roles.Add(rolNuevo);
                _contexto.SaveChanges();
                return Ok(rolNuevo);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/roles")]
        public IActionResult updateRol([FromBody] Roles rolModificar)
        {
            try
            {
                Roles rol = (from r in _contexto.roles
                                              where r.idRol == rolModificar.idRol
                                              select r).FirstOrDefault();

                if (rol is null)
                {
                    return NotFound();
                }

                rol.idRol = rolModificar.idRol;
                rol.Rol = rolModificar.Rol;
                rol.Estado = rolModificar.Estado;

                _contexto.Entry(rol).State = EntityState.Modified;
                _contexto.SaveChanges();

                return Ok(rol);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
