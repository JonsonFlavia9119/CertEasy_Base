using System.ComponentModel.DataAnnotations;

namespace CertEasy.Model
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string? LogLevel { get; set; }
        public string? Message { get; set; }
        public string? Exception { get; set; }
        public string? EntityType { get; set; }
        public string? EntityID { get; set; }
        public int? UserID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}