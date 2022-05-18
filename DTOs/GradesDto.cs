namespace aim_backend.DTOs
{
    public class GradesDto
    {
        public int StudentId { get; set; }

        public int GradeId { get; set; }

        public string CourseName { get; set; }

        public int GradeValue { get; set; }
    }

    public class GetGradesDto 
    {
        public int StudentId { get; set; }

        public int YearOfStudy { get; set; }
    }
}