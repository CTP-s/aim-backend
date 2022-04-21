using System.ComponentModel.DataAnnotations;

namespace aim_backend.DTOs
{
    public class UserCredentialsDto
    {
        [Required]
        public int id { get; set; }
        
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}