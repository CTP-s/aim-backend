using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class OptionalCourse : Course
    {
        public int MaxNumberStudents { get; set; }

        public int Approved { get; set; }
    }
}