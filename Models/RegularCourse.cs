using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class RegularCourse : Course
    {
        public int CurriculumId { get; set; }
    }
}