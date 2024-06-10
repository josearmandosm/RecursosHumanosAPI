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
    public class CapacitacionsController : ControllerBase
    {
        private readonly RecursosHumanosDbContext _context;
        private readonly IMapper _mapper;

        public CapacitacionsController(RecursosHumanosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Capacitacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapacitacionGetDTO>>> GetCapacitacions()
        {
            var capacitacions = await _context.Capacitacions.ToListAsync();
            var capacitacionDTOs = _mapper.Map<List<CapacitacionGetDTO>>(capacitacions);
            return capacitacionDTOs;
        }

        // GET: api/Capacitacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CapacitacionGetDTO>> GetCapacitacion(int id)
        {
            var capacitacion = await _context.Capacitacions.FindAsync(id);

            if (capacitacion == null)
            {
                return NotFound();
            }

            var capacitacionDTO = _mapper.Map<CapacitacionGetDTO>(capacitacion);
            return capacitacionDTO;
        }

        // PUT: api/Capacitacions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapacitacion(int id, CapacitacionUpdateDTO capacitacionDTO)
        {
            if (id != capacitacionDTO.CapacitacionId)
            {
                return BadRequest();
            }

            var capacitacion = _mapper.Map<Capacitacion>(capacitacionDTO);
            _context.Entry(capacitacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapacitacionExists(id))
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

        // POST: api/Capacitacions
        [HttpPost]
        public async Task<ActionResult<CapacitacionGetDTO>> PostCapacitacion(CapacitacionInsertDTO capacitacionDTO)
        {
            var capacitacion = _mapper.Map<Capacitacion>(capacitacionDTO);
            _context.Capacitacions.Add(capacitacion);
            await _context.SaveChangesAsync();

            var createdCapacitacionDTO = _mapper.Map<CapacitacionGetDTO>(capacitacion);

            return CreatedAtAction("GetCapacitacion", new { id = createdCapacitacionDTO.CapacitacionId }, createdCapacitacionDTO);
        }

        // DELETE: api/Capacitacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCapacitacion(int id)
        {
            var capacitacion = await _context.Capacitacions.FindAsync(id);
            if (capacitacion == null)
            {
                return NotFound();
            }

            _context.Capacitacions.Remove(capacitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CapacitacionExists(int id)
        {
            return _context.Capacitacions.Any(e => e.CapacitacionId == id);
        }
    }
}
