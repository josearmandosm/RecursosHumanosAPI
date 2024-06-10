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
    public class PuestoesController : ControllerBase
    {
        private readonly RecursosHumanosDbContext _context;
        private readonly IMapper _mapper;

        public PuestoesController(RecursosHumanosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Puestoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuestoGetDTO>>> GetPuestos()
        {
            var puestos = await _context.Puestos.ToListAsync();
            var puestoDTOs = _mapper.Map<List<PuestoGetDTO>>(puestos);
            return puestoDTOs;
        }

        // GET: api/Puestoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PuestoGetDTO>> GetPuesto(int id)
        {
            var puesto = await _context.Puestos.FindAsync(id);

            if (puesto == null)
            {
                return NotFound();
            }

            var puestoDTO = _mapper.Map<PuestoGetDTO>(puesto);
            return puestoDTO;
        }

        // PUT: api/Puestoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuesto(int id, PuestoUpdateDTO puestoDTO)
        {
            if (id != puestoDTO.PuestoId)
            {
                return BadRequest();
            }

            var puesto = _mapper.Map<Puesto>(puestoDTO);
            _context.Entry(puesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestoExists(id))
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

        // POST: api/Puestoes
        [HttpPost]
        public async Task<ActionResult<PuestoGetDTO>> PostPuesto(PuestoInsertDTO puestoDTO)
        {
            var puesto = _mapper.Map<Puesto>(puestoDTO);
            _context.Puestos.Add(puesto);
            await _context.SaveChangesAsync();

            var createdPuestoDTO = _mapper.Map<PuestoGetDTO>(puesto);

            return CreatedAtAction("GetPuesto", new { id = createdPuestoDTO.PuestoId }, createdPuestoDTO);
        }

        // DELETE: api/Puestoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuesto(int id)
        {
            var puesto = await _context.Puestos.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }

            _context.Puestos.Remove(puesto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PuestoExists(int id)
        {
            return _context.Puestos.Any(e => e.PuestoId == id);
        }
    }
}
