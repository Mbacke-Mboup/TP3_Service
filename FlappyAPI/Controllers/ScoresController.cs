using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlappyAPI.Data;
using FlappyAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FlappyAPI.Modelss;
using System.Security.Claims;

namespace FlappyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly FlappyAPIContext _context;
        readonly UserManager<User> UserManager;

       

        public ScoresController(FlappyAPIContext context, UserManager<User> userManager)
        {
            _context = context;
            UserManager = userManager;
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

        [HttpGet]
        public async Task<ActionResult<Score>> GetMyScores()
        {
          if (_context.Score == null)
          {
              return NotFound();
          }
          string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                var scores = user.Scores.ToList();
                return Ok(scores);
            }
           

            return NotFound();

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
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
          if (_context.Score == null)
          {
              return Problem("Entity set 'FlappyAPIContext.Score'  is null.");
          }

            User user = await UserManager.FindByNameAsync(score.Pseudo);
            score.User = user;
            score.Date = DateTime.Now.ToString();
            user.Scores.Add(score);
            _context.Score.Add(score);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok(score);
        }

        

        private bool ScoreExists(int id)
        {
            return (_context.Score?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
