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
    public class RolesporUsuarioController : ControllerBase
    {
        private readonly rolesContext _contexto;

        public RolesporUsuarioController(rolesContext miContexto)
        {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/roles_por_usuario")]
        public IActionResult Get()
        {
            var rolesUsuarioList = (from ru in _contexto.rolesporusuarios
                                    join r in _contexto.roles on ru.idRol equals r.idRol
                                    join u in _contexto.usuario on ru.idUsuario equals u.idUsuario
                                    select new
                                    {
                                        ru.IdRolporUsuario,
                                        ru.idRol,
                                        r.Rol,
                                        ru.idUsuario,
                                        u.NombreUsuario,
                                        ru.Estado,
                                        ru.FechaCreacion,
                                        ru.Fechamodificacion
                                    });

            if (rolesUsuarioList.Count() > 0)
            {
                return Ok(rolesUsuarioList);
            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/roles_por_usuario/{idRolUsuario}")]
        public IActionResult Get(int idRolUsuario)
        {
            var roles = (from ru in _contexto.rolesporusuarios
                        join r in _contexto.roles on ru.idRol equals r.idRol
                        join u in _contexto.usuario on ru.idUsuario equals u.idUsuario
                        where ru.IdRolporUsuario == idRolUsuario
                        select new
                        {
                            ru.IdRolporUsuario,
                            ru.idRol,
                            r.Rol,
                            ru.idUsuario,
                            u.NombreUsuario,
                            ru.Estado,
                            ru.FechaCreacion,
                            ru.Fechamodificacion
                        });


            if (roles.Count() > 0)
            {
                return Ok(roles);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/roles_por_usuario")]
        public IActionResult guardarRolUsuario([FromBody] RolesporUsuario rolUsuarioNuevo)
        {
            try
            {
                _contexto.rolesporusuarios.Add(rolUsuarioNuevo);
                _contexto.SaveChanges();
                return Ok(rolUsuarioNuevo);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/roles_por_usuario")]
        public IActionResult updateRolUsuario([FromBody] RolesporUsuario rolUsuarioModificar)
        {
            try
            {
                RolesporUsuario rolUsuario = (from ru in _contexto.rolesporusuarios
                                             where ru.idRol == rolUsuarioModificar.idRol
                                             select ru).FirstOrDefault();

                if (rolUsuario is null)
                {
                    return NotFound();
                }

                rolUsuario.idRol = rolUsuarioModificar.idRol;
                rolUsuario.idUsuario = rolUsuarioModificar.idUsuario;
                rolUsuario.Estado = rolUsuarioModificar.Estado;
                rolUsuario.FechaCreacion = rolUsuarioModificar.FechaCreacion;
                rolUsuario.Fechamodificacion = rolUsuarioModificar.Fechamodificacion;

                _contexto.Entry(rolUsuario).State = EntityState.Modified;
                _contexto.SaveChanges();

                return Ok(rolUsuario);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

    }
}
