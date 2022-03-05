using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using _2019LD601.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _2019LD601.Controllers
{
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly rolesContext _contexto;

        public DepartamentosController(rolesContext miContexto)
        {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/departamentos")]
        public IActionResult Get()
        {
            IEnumerable<Departamentos> departamentosList = from d in _contexto.departamentos
                                               select d;

            if (departamentosList.Count() > 0)
            {
                return Ok(departamentosList);
            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/departamentos/{idDept}")]
        public IActionResult Get(int idDept)
        {
            IEnumerable<Departamentos> departamentos = from d in _contexto.departamentos
                                           where d.id == idDept
                                           select d;


            if (departamentos.Count() > 0)
            {
                return Ok(departamentos);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/departamentos")]
        public IActionResult guardarDepartamento([FromBody] Departamentos departamentoNuevo)
        {
            try
            {
                _contexto.departamentos.Add(departamentoNuevo);
                _contexto.SaveChanges();
                return Ok(departamentoNuevo);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/departamentos")]
        public IActionResult updateDepartamento([FromBody] Departamentos departementoModificar)
        {
            try
            {
                Departamentos departamento = (from d in _contexto.departamentos
                                        where d.id == departementoModificar.id
                                        select d).FirstOrDefault();

                if (departamento is null)
                {
                    return NotFound();
                }

                departamento.id = departementoModificar.id;
                departamento.departamento = departementoModificar.departamento;

                _contexto.Entry(departamento).State = EntityState.Modified;
                _contexto.SaveChanges();

                return Ok(departamento);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
