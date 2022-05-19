using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        // [ForeignKey("studentId")]
        // public Student Student { get; set; }

        // [ForeignKey("yearOfStudyId")]
        // public YearOfStudy yearOfStudy { get; set; }

        public int StudentId { get; set; }

        public int YearOfStudyId { get; set; }
    }
}