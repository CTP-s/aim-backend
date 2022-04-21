using System.ComponentModel.DataAnnotations;

namespace aim_backend.DTOs
{
    public class UserCredentialsDto
    {   
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string discriminator { get; set; }
        
    }
}