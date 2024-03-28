using FlappyAPI.Modelss;
using System.Text.Json.Serialization;

namespace FlappyAPI.Models
{
    public class Score
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Date { get; set; }
        public string TimeInSeconds { get; set; }
        public int ScoreValue { get; set; }
        public bool IsPublic { get; set; }
        public string UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }

    }
}
