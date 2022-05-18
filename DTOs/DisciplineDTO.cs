namespace aim_backend.DTOs
{
    public class DisciplineDTO
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int LecturerId { get; set; }

        public string LecturerFirstName { get; set; }
        
        public string LecturerLastName { get; set; }
    }
}