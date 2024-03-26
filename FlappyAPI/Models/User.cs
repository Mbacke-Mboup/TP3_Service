using FlappyAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace FlappyAPI.Modelss
{
    public class User : IdentityUser
    {
        public virtual List<Score> Scores { get; set; } = null!;
    }
}
