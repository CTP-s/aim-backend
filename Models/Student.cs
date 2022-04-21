namespace aim_backend.Models
{
    public class Student : User
    {
        public int groupId { get; set; }

        public int optionalCourseId { get; set; }
        
    }
}