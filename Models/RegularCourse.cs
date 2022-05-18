using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class RegularCourse : Course
    {
        // [ForeignKey("curriculumId")]
        // public Curriculum Curriculum { get; set; }

        public int CurriculumId { get; set; }
    }
}