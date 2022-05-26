using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class Curriculum
    {
        [Key]
        public int CurriculumId { get; set; }
        public int YearOfStudyId { get; set; }
    }
}