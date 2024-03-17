using Microsoft.Build.Evaluation;

namespace CarSharing.Server.Models.JWT
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpitesHours { get; set; }
    }
}
