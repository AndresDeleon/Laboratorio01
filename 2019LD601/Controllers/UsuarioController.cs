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
    public class UsuarioController : ControllerBase
    {
        private readonly rolesContext _contexto;

        public UsuarioController(rolesContext miContexto)
        {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/usuarios")]
        public IActionResult Get()
        {
            var usuariosList = (from u in _contexto.usuario
                                join d in _contexto.departamentos on u.departamentoId equals d.id
                                select new {
                                    u.idUsuario,
                                    u.NombreUsuario,
                                    u.departamentoId,
                                    d.departamento,
                                    u.Clave,
                                    u.Estado
                                });

            if (usuariosList.Count() > 0)
            {
                return Ok(usuariosList);
            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/usuarios/{idUsuario}")]
        public IActionResult Get(int idUsuario)
        {
            var usuario = (from u in _contexto.usuario
                            join d in _contexto.departamentos on u.departamentoId equals d.id
                            where u.idUsuario == idUsuario
                            select new
                            {
                                u.idUsuario,
                                u.NombreUsuario,
                                u.departamentoId,
                                d.departamento,
                                u.Clave,
                                u.Estado
                            });


            if (usuario.Count() > 0)
            {
                return Ok(usuario);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/usuarios")]
        public IActionResult guardarUsuario([FromBody] Usuario usuarioNuevo)
        {
            try
            {
                _contexto.usuario.Add(usuarioNuevo);
                _contexto.SaveChanges();
                return Ok(usuarioNuevo);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/usuarios")]
        public IActionResult updateUsuario([FromBody] Usuario usuarioModificar)
        {
            try
            {
                Usuario usuario = (from u in _contexto.usuario
                             where u.idUsuario == usuarioModificar.idUsuario
                             select u).FirstOrDefault();

                if (usuario is null)
                {
                    return NotFound();
                }

                usuario.idUsuario = usuarioModificar.idUsuario;
                usuario.NombreUsuario = usuarioModificar.NombreUsuario;
                usuario.departamentoId = usuarioModificar.departamentoId;
                usuario.Clave = usuarioModificar.Clave;
                usuario.Estado = usuarioModificar.Estado;

                _contexto.Entry(usuario).State = EntityState.Modified;
                _contexto.SaveChanges();

                return Ok(usuario);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

    }
}
