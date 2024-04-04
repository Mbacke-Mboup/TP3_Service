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
using Castle.Core.Internal;

namespace FlappyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly ScoreService _service;

       

        public ScoresController(ScoreService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetPublicScores()
        {
          if (!_service.APIWorking())
          {
              return NotFound();
          }
            
            return await _service.GetAllScores();
        }

        [HttpGet]
        public async Task<ActionResult<Score>> GetMyScores()
        {
          if (!_service.APIWorking())
          {
              return NotFound();
          }
          string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            List<Score> scores = await _service.GetScoresOf(userId);
            if (scores != null)
            {
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

            if(!await _service.ChangeScoreVisibility(score, userId))
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new { Message = "Vous n'êtes pas authorisé à faire cela." }
                    );
            }
           
            return NoContent();
        }

        // POST: api/Scores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
          if (!_service.APIWorking())
          {
              return Problem("Entity set 'FlappyAPIContext.Score'  is null.");
          }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var scoreResult = await _service.AddScore(score,userId);
            if(scoreResult != null) {
                
                return Ok(scoreResult);

            }
            return  StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "La création du score a échoué." }
                    );


        }

        

        
    }
}
