namespace aim_backend.Models
{
    public class Teacher : User
    {
        public int firstOptionalCourseId { get; set; }

        public int secondOptionalCourseId { get; set; }
    }
}