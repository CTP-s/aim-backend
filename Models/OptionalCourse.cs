using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class OptionalCourse : Course
    {
        public int maxNumberStudents { get; set; }
    }
}