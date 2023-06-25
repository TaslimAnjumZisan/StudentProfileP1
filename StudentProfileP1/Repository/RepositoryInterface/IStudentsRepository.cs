using StudentProfileP1.Models;

namespace StudentProfileP1.Repository.RepositoryInterface
{
    public interface IStudentsRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Boolean> CreateStudentAsync(Student model, CancellationToken cancellationToken = default);

    }
}
