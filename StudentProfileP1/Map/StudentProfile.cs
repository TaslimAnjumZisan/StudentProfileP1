using AutoMapper;
using StudentProfileP1.Models;
using StudentProfileP1.ViewModel;

namespace StudentProfileP1.Map
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentIndexModel>().ReverseMap();
            CreateMap<Student, StudentCreateModel>().ReverseMap();
        }

    }
}
