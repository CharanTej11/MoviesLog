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
    public class ReviewsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReviewsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAll()
        {
            var reviews = await _context.Reviews.ToListAsync();
            var dtoList = _mapper.Map<List<ReviewDto>>(reviews);
            return Ok(dtoList);
        }

        // GET: api/reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDto>> GetById(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
                return NotFound();

            var dto = _mapper.Map<ReviewDto>(review);
            return Ok(dto);
        }

        // POST: api/reviews
        [HttpPost]
        public async Task<ActionResult<ReviewDto>> Create([FromBody] ReviewCreateDto dto)
        {
            var review = _mapper.Map<Review>(dto);
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            var resultDto = _mapper.Map<ReviewDto>(review);
            return CreatedAtAction(nameof(GetById), new { id = resultDto.Id }, resultDto);
        }

        // PUT: api/reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReviewDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
                return NotFound();

            _mapper.Map(dto, review);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
                return NotFound();

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
