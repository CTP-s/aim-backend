using aim_backend.DTOs;
using aim_backend.Models;
using AutoMapper;

namespace aim_backend.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<User, UserCredentialsDto>();
            CreateMap<UserCredentialsDto, User>();
            CreateMap<UserCredentialsDto, Student>();
            CreateMap<UserCredentialsDto, Teacher>();
            CreateMap<User, UserLoginResponseDto>();
            CreateMap<OptionalCourse, DisciplineDTO>();
            CreateMap<User, StudentDto>();
            CreateMap<StudentDto, User>();
            CreateMap<Grade, GradeDto>();
            CreateMap<GradeDto, Grade>();
            CreateMap<EnrollDto, Enrollment>();
            CreateMap<Enrollment, EnrollDto>();
            CreateMap<User, StudentInfoDto>();
            CreateMap<StudentInfoDto, User>();
            CreateMap<User, TeacherInfoDto>();
            CreateMap<TeacherInfoDto, User>();
            CreateMap<OptionalCourse, OptionalCourseProposedDto>();
            CreateMap<OptionalCourseProposedDto, OptionalCourse>();
            CreateMap<User, UserUpdateDTO>();
            CreateMap<UserUpdateDTO, User>();
        }
    }
}