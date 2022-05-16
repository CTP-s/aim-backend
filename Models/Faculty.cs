using System.ComponentModel.DataAnnotations;

namespace aim_backend.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        public string FacultyName { get; set; }
    }
}