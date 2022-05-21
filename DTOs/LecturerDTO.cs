namespace aim_backend.DTOs
{
    public class LecturerDTO
    {
        public int LecturerId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int CourseSemester { get; set; }
    }
}