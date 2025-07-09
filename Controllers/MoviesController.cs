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
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        //private readonly ILogger<MoviesController> _logger;

        //public MoviesController(ILogger<MoviesController> logger)
        //{
        //    _logger = logger;
        //}

        public MoviesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAll()
        {
            var movies = await _context.Movies.ToListAsync();
            //_logger.LogInformation("Fetching movie with ID {id}", movies);
            Console.WriteLine(movies);
            
            var dtoList = _mapper.Map<List<MovieDto>>(movies);
           
            return Ok(dtoList);
        }

        // GET: api/movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound();

            var dto = _mapper.Map<MovieDto>(movie);
            return Ok(dto);
        }

        // POST: api/movies
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReviewCreateDto dto)
        {
            // ✅ Check if MovieId exists
            var movieExists = await _context.Movies.AnyAsync(m => m.Id == dto.MovieId);
            if (!movieExists)
            {
                return BadRequest($"Movie with Id {dto.MovieId} does not exist.");
            }

            var review = _mapper.Map<Review>(dto);
            review.PostedAt = DateTime.UtcNow;

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            var resultDto = _mapper.Map<ReviewDto>(review);
            return CreatedAtAction(nameof(GetById), new { id = resultDto.Id }, resultDto);
        }


        // PUT: api/movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MovieDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound();

            _mapper.Map(dto, movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
