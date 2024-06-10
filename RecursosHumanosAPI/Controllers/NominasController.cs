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
    public class NominasController : ControllerBase
    {
        private readonly RecursosHumanosDbContext _context;
        private readonly IMapper _mapper;

        public NominasController(RecursosHumanosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Nominas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NominaGetDTO>>> GetNominas()
        {
            var nominas = await _context.Nominas.ToListAsync();
            var nominaDTOs = _mapper.Map<List<NominaGetDTO>>(nominas);
            return nominaDTOs;
        }

        // GET: api/Nominas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NominaGetDTO>> GetNomina(int id)
        {
            var nomina = await _context.Nominas.FindAsync(id);

            if (nomina == null)
            {
                return NotFound();
            }

            var nominaDTO = _mapper.Map<NominaGetDTO>(nomina);
            return nominaDTO;
        }

        // PUT: api/Nominas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNomina(int id, NominaUpdateDTO nominaDTO)
        {
            if (id != nominaDTO.NominaId)
            {
                return BadRequest();
            }

            var nomina = _mapper.Map<Nomina>(nominaDTO);
            _context.Entry(nomina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NominaExists(id))
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

        // POST: api/Nominas
        [HttpPost]
        public async Task<ActionResult<NominaGetDTO>> PostNomina(NominaInsertDTO nominaDTO)
        {
            var nomina = _mapper.Map<Nomina>(nominaDTO);
            _context.Nominas.Add(nomina);
            await _context.SaveChangesAsync();

            var createdNominaDTO = _mapper.Map<NominaGetDTO>(nomina);

            return CreatedAtAction("GetNomina", new { id = createdNominaDTO.NominaId }, createdNominaDTO);
        }

        // DELETE: api/Nominas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNomina(int id)
        {
            var nomina = await _context.Nominas.FindAsync(id);
            if (nomina == null)
            {
                return NotFound();
            }

            _context.Nominas.Remove(nomina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NominaExists(int id)
        {
            return _context.Nominas.Any(e => e.NominaId == id);
        }
    }
}
