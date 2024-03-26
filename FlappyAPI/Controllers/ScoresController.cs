using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlappyAPI.Data;
using FlappyAPI.Models;

namespace FlappyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly FlappyAPIContext _context;

        public ScoresController(FlappyAPIContext context)
        {
            _context = context;
        }

        // GET: api/Scores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetPublicScores()
        {
          if (_context.Score == null)
          {
              return NotFound();
          }
            return await _context.Score.ToListAsync();
        }

        // GET: api/Scores/5
        [HttpGet]
        public async Task<ActionResult<Score>> GetMyScores()
        {
          if (_context.Score == null)
          {
              return NotFound();
          }
            var score = await _context.Score.FindAsync();

            if (score == null)
            {
                return NotFound();
            }

            return score;
        }

        // PUT: api/Scores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeScoreVisibility(int id, Score score)
        {
            if (id != score.Id)
            {
                return BadRequest();
            }

            _context.Entry(score).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreExists(id))
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

        // POST: api/Scores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
          if (_context.Score == null)
          {
              return Problem("Entity set 'FlappyAPIContext.Score'  is null.");
          }
            _context.Score.Add(score);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScore", new { id = score.Id }, score);
        }

        

        private bool ScoreExists(int id)
        {
            return (_context.Score?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
