using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecursosHumanosAPI.DTOs;
using RecursosHumanosAPI.Models;

namespace RecursosHumanosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly RecursosHumanosDbContext _context;
        private readonly IMapper _mapper;

        public DepartamentosController(RecursosHumanosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Departamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartamentoGetDTO>>> GetDepartamentos()
        {
            var departamentos = await _context.Departamentos.ToListAsync();
            var departamentoDTOs = _mapper.Map<List<DepartamentoGetDTO>>(departamentos);
            return departamentoDTOs;
        }

        // GET: api/Departamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentoGetDTO>> GetDepartamento(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            var departamentoDTO = _mapper.Map<DepartamentoGetDTO>(departamento);
            return departamentoDTO;
        }

        // PUT: api/Departamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamento(int id, DepartamentoUpdateDTO departamentoDTO)
        {
            if (id != departamentoDTO.DepartamentoId)
            {
                return BadRequest();
            }

            var departamento = _mapper.Map<Departamento>(departamentoDTO);
            _context.Entry(departamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Departamentos
        [HttpPost]
        public async Task<ActionResult<DepartamentoGetDTO>> PostDepartamento(DepartamentoInsertDTO departamentoDTO)
        {
            var departamento = _mapper.Map<Departamento>(departamentoDTO);
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();

            var createdDepartamentoDTO = _mapper.Map<DepartamentoGetDTO>(departamento);

            return CreatedAtAction("GetDepartamento", new { id = createdDepartamentoDTO.DepartamentoId }, createdDepartamentoDTO);
        }

        // DELETE: api/Departamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.DepartamentoId == id);
        }
    }
}
