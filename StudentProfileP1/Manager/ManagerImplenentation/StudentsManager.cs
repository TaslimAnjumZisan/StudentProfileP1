using AutoMapper;
using StudentProfileP1.Manager.ManagerInterface;
using StudentProfileP1.Models;
using StudentProfileP1.Repository.RepositoryInterface;
using StudentProfileP1.ViewModel;

namespace StudentProfileP1.Manager.ManagerImplenentation
{
    public class StudentsManager:IStudentsManager
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IMapper _mapper;

        public StudentsManager(IStudentsRepository studentsRepository,IMapper mapper)
        {
            _studentsRepository = studentsRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentIndexModel>> GetAllStudentsAsync()
        {
            var existListOfStudent = await _studentsRepository.GetAllStudentsAsync();
            var studentList = _mapper.Map<List<Student>, List<StudentIndexModel>>(existListOfStudent);
            return studentList;
        }

        public async Task<Boolean> CreateStudentAsync(StudentCreateModel model)
        {
            var student = _mapper.Map<StudentCreateModel, Student>(model);
            Boolean result = await _studentsRepository.CreateStudentAsync(student);
            return result;

        }
    }
}
