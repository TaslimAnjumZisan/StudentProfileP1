using StudentProfileP1.ViewModel;

namespace StudentProfileP1.Manager.ManagerInterface
{
    public interface IStudentsManager
    {
        Task<List<StudentIndexModel>> GetAllStudentsAsync();
        Task<Boolean> CreateStudentAsync(StudentCreateModel model);

    }
}
