namespace aim_backend.DTOs
{
    public class DisciplineDTO
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int Semester { get; set; }

        public string Discriminator { get; set; }

        public int LecturerId { get; set; }

        public string LecturerFirstName { get; set; }

        public string LecturerLastName { get; set; }

        public float? DisciplineMean { get; set; }

        public int? MaxNumberStudents { get; set; }

    }
}
