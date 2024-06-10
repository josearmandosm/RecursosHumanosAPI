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
    public class EvaluacionsController : ControllerBase
    {
        private readonly RecursosHumanosDbContext _context;
        private readonly IMapper _mapper;

        public EvaluacionsController(RecursosHumanosDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Evaluacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvaluacionGetDTO>>> GetEvaluacions()
        {
            var evaluacions = await _context.Evaluacions.ToListAsync();
            var evaluacionDTOs = _mapper.Map<List<EvaluacionGetDTO>>(evaluacions);
            return evaluacionDTOs;
        }

        // GET: api/Evaluacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EvaluacionGetDTO>> GetEvaluacion(int id)
        {
            var evaluacion = await _context.Evaluacions.FindAsync(id);

            if (evaluacion == null)
            {
                return NotFound();
            }

            var evaluacionDTO = _mapper.Map<EvaluacionGetDTO>(evaluacion);
            return evaluacionDTO;
        }

        // PUT: api/Evaluacions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvaluacion(int id, EvaluacionUpdateDTO evaluacionDTO)
        {
            if (id != evaluacionDTO.EvaluacionId)
            {
                return BadRequest();
            }

            var evaluacion = _mapper.Map<Evaluacion>(evaluacionDTO);
            _context.Entry(evaluacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluacionExists(id))
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

        // POST: api/Evaluacions
        [HttpPost]
        public async Task<ActionResult<EvaluacionGetDTO>> PostEvaluacion(EvaluacionInsertDTO evaluacionDTO)
        {
            var evaluacion = _mapper.Map<Evaluacion>(evaluacionDTO);
            _context.Evaluacions.Add(evaluacion);
            await _context.SaveChangesAsync();

            var createdEvaluacionDTO = _mapper.Map<EvaluacionGetDTO>(evaluacion);

            return CreatedAtAction("GetEvaluacion", new { id = createdEvaluacionDTO.EvaluacionId }, createdEvaluacionDTO);
        }

        // DELETE: api/Evaluacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluacion(int id)
        {
            var evaluacion = await _context.Evaluacions.FindAsync(id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            _context.Evaluacions.Remove(evaluacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvaluacionExists(int id)
        {
            return _context.Evaluacions.Any(e => e.EvaluacionId == id);
        }
    }
}
