using System.ComponentModel.DataAnnotations;

namespace aim_backend.DTOs
{
    public class GradeDto
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int Value { get; set; }
    }
}