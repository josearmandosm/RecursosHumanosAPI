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
    public class VacacionsController : ControllerBase
    {
        private readonly RecursosHumanosDbContext _context;
        private readonly IMapper _mapper;

        public VacacionsController(RecursosHumanosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Vacacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacacionGetDTO>>> GetVacacions()
        {
            var vacaciones = await _context.Vacacions.ToListAsync();
            var vacacionesDTO = _mapper.Map<List<VacacionGetDTO>>(vacaciones);
            return vacacionesDTO;
        }

        // GET: api/Vacacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VacacionGetDTO>> GetVacacion(int id)
        {
            var vacacion = await _context.Vacacions.FindAsync(id);

            if (vacacion == null)
            {
                return NotFound();
            }

            var vacacionDTO = _mapper.Map<VacacionGetDTO>(vacacion);
            return vacacionDTO;
        }

        // PUT: api/Vacacions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacacion(int id, VacacionUpdateDTO vacacionDTO)
        {
            if (id != vacacionDTO.VacacionId)
            {
                return BadRequest();
            }

            var vacacion = _mapper.Map<Vacacion>(vacacionDTO);
            _context.Entry(vacacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacacionExists(id))
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

        // POST: api/Vacacions
        [HttpPost]
        public async Task<ActionResult<VacacionGetDTO>> PostVacacion(VacacionInsertDTO vacacionDTO)
        {
            var vacacion = _mapper.Map<Vacacion>(vacacionDTO);
            _context.Vacacions.Add(vacacion);
            await _context.SaveChangesAsync();

            var createdVacacionDTO = _mapper.Map<VacacionGetDTO>(vacacion);

            return CreatedAtAction("GetVacacion", new { id = createdVacacionDTO.VacacionId }, createdVacacionDTO);
        }

        // DELETE: api/Vacacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacacion(int id)
        {
            var vacacion = await _context.Vacacions.FindAsync(id);
            if (vacacion == null)
            {
                return NotFound();
            }

            _context.Vacacions.Remove(vacacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VacacionExists(int id)
        {
            return _context.Vacacions.Any(e => e.VacacionId == id);
        }
    }
}
