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

       

        public ScoresController(FlappyAPIContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetPublicScores()
        {
          if (_context.Score == null)
          {
              return NotFound();
          }
            
            return await _context.Score.Where(s => s.IsPublic).ToListAsync();
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
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeScoreVisibility(int id, Score score)
        {
            if (id != score.Id)
            {
                return BadRequest();
            }
            
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            if(user == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new { Message = "Vous n'êtes pas authorisé à faire cela." }
                    );
            }
            Score scoreFinale = await _context.Score.FindAsync(score.Id);
            scoreFinale.IsPublic = score.IsPublic;
            _context.Score.Update(scoreFinale);

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

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);
            if(user != null) {
                score.User = user;
                score.Date = DateTime.Now.ToString();
                score.Pseudo = user.UserName;
                user.Scores.Add(score);
                _context.Score.Add(score);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return Ok(score);

            }
            return  StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "La création du score a échoué." }
                    );


        }

        

        private bool ScoreExists(int id)
        {
            return (_context.Score?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
