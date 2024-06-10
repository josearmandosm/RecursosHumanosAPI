using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecursosHumanosAPI.DTOs;
using RecursosHumanosAPI.Models;
using RecursosHumanosAPI.Models.DTOs.Empleado;

namespace RecursosHumanosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoesController : ControllerBase
    {
        private readonly RecursosHumanosDbContext _context;
        private readonly IMapper _mapper;

        public EmpleadoesController(RecursosHumanosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Empleadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoGetDTO>>> GetEmpleados()
        {
            var empleados = await _context.Empleados.ToListAsync();
            var empleadoDTOs = _mapper.Map<List<EmpleadoGetDTO>>(empleados);
            return empleadoDTOs;
        }

        // GET: api/Empleadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoGetDTO>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            var empleadoDTO = _mapper.Map<EmpleadoGetDTO>(empleado);
            return empleadoDTO;
        }

        // PUT: api/Empleadoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, EmpleadoUpdateDTO empleadoDTO)
        {
            if (id != empleadoDTO.EmpleadoId)
            {
                return BadRequest();
            }

            var empleado = _mapper.Map<Empleado>(empleadoDTO);
            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        // POST: api/Empleadoes
        [HttpPost]
        public async Task<ActionResult<EmpleadoGetDTO>> PostEmpleado(EmpleadoInsertDTO empleadoDTO)
        {
            var empleado = _mapper.Map<Empleado>(empleadoDTO);
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            var createdEmpleadoDTO = _mapper.Map<EmpleadoGetDTO>(empleado);

            return CreatedAtAction("GetEmpleado", new { id = createdEmpleadoDTO.EmpleadoId }, createdEmpleadoDTO);
        }

        // DELETE: api/Empleadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.EmpleadoId == id);
        }
    }
}
