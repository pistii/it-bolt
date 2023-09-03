using System.ComponentModel.DataAnnotations;

namespace ApiClient.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string? nev { get; set; }

        [Required]
        public string? Jelszo { get; set; }
    }
}
