using FlappyAPI.Models;
using FlappyAPI.Modelss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FlappyAPI.Data
{
    public class ScoreService
    {
        protected readonly FlappyAPIContext _context;

        public ScoreService(FlappyAPIContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Score>>> GetAllScores()
        {
            if (_context.Score == null)
            {
                return null;
            }

            return await _context.Score.Where(s => s.IsPublic).ToListAsync();
        }

        public async Task<List<Score>> GetScoresOf(string userId)
        {
            if (_context.Score == null)
            {
                return null;
            }

            User? user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                var scores = user.Scores.ToList();
                return scores;
            }


            return null;

        }

        public async Task<bool> ChangeScoreVisibility(Score score, string userId)
        {


            User? user = await _context.Users.FindAsync(userId);
            if (user == null || user.UserName != score.Pseudo)
            {
                return false;
            }
            Score scoreFinale = await _context.Score.FindAsync(score.Id);
            scoreFinale.IsPublic = score.IsPublic;
            _context.Score.Update(scoreFinale);
            await _context.SaveChangesAsync();
            return true;
               
            

            
        }

        public async Task<Score> AddScore(Score score, string userId)
        {


            User? user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                score.User = user;
                score.Date = DateTime.Now.ToString();
                score.Pseudo = user.UserName;
                user.Scores.Add(score);
                _context.Score.Add(score);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return score;
            }

            return null;
            
            


        }



        public bool APIWorking()
        {
            return _context.Score != null;
        }

        private bool ScoreExists(int id)
        {
            return (_context.Score?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

