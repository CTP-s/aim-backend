using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class Optional
    {
        [Key]
        public int OptionalId { get; set; }

        public string OptionalName { get; set; }

        [ForeignKey("teacherId")]
        public Teacher Teacher { get; set; }

        public int maxNumberStudents { get; set; }
    }
}