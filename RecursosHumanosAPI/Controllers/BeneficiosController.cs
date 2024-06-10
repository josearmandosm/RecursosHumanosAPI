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
    public class BeneficiosController : ControllerBase
    {
        private readonly RecursosHumanosDbContext _context;
        private readonly IMapper _mapper;

        public BeneficiosController(RecursosHumanosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Beneficios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeneficioGetDTO>>> GetBeneficios()
        {
            var beneficios = await _context.Beneficios.ToListAsync();
            var beneficioDTOs = _mapper.Map<List<BeneficioGetDTO>>(beneficios);
            return beneficioDTOs;
        }

        // GET: api/Beneficios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BeneficioGetDTO>> GetBeneficio(int id)
        {
            var beneficio = await _context.Beneficios.FindAsync(id);

            if (beneficio == null)
            {
                return NotFound();
            }

            var beneficioDTO = _mapper.Map<BeneficioGetDTO>(beneficio);
            return beneficioDTO;
        }

        // PUT: api/Beneficios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeneficio(int id, BeneficioUpdateDTO beneficioDTO)
        {
            if (id != beneficioDTO.BeneficioId)
            {
                return BadRequest();
            }

            var beneficio = _mapper.Map<Beneficio>(beneficioDTO);
            _context.Entry(beneficio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficioExists(id))
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

        // POST: api/Beneficios
        [HttpPost]
        public async Task<ActionResult<BeneficioGetDTO>> PostBeneficio(BeneficioInsertDTO beneficioDTO)
        {
            var beneficio = _mapper.Map<Beneficio>(beneficioDTO);
            _context.Beneficios.Add(beneficio);
            await _context.SaveChangesAsync();

            var createdBeneficioDTO = _mapper.Map<BeneficioGetDTO>(beneficio);

            return CreatedAtAction("GetBeneficio", new { id = createdBeneficioDTO.BeneficioId }, createdBeneficioDTO);
        }

        // DELETE: api/Beneficios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeneficio(int id)
        {
            var beneficio = await _context.Beneficios.FindAsync(id);
            if (beneficio == null)
            {
                return NotFound();
            }

            _context.Beneficios.Remove(beneficio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeneficioExists(int id)
        {
            return _context.Beneficios.Any(e => e.BeneficioId == id);
        }
    }
}
