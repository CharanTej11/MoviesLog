using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesLog.Data;
using MoviesLog.DTOs;
using MoviesLog.Models;
using AutoMapper;

namespace MoviesLog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DirectorsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/directors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorDto>>> GetAll()
        {
            var directors = await _context.Directors.ToListAsync();
            var dtoList = _mapper.Map<List<DirectorDto>>(directors);
            Console.WriteLine(dtoList);
            return Ok(dtoList);
        }

        // GET: api/directors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDto>> GetById(int id)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null)
                return NotFound();

            var dto = _mapper.Map<DirectorDto>(director);
            return Ok(dto);
        }

        // POST: api/directors
        [HttpPost]
        public async Task<ActionResult<DirectorDto>> Create([FromBody] DirectorCreateDto dto)
        {
            var director = _mapper.Map<Director>(dto);
            _context.Directors.Add(director);
            await _context.SaveChangesAsync();

            var resultDto = _mapper.Map<DirectorDto>(director);
            return CreatedAtAction(nameof(GetById), new { id = resultDto.Id }, resultDto);
        }

        // PUT: api/directors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DirectorDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            var director = await _context.Directors.FindAsync(id);
            if (director == null)
                return NotFound();

            _mapper.Map(dto, director);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/directors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null)
                return NotFound();

            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
