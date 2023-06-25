using Microsoft.EntityFrameworkCore;
using StudentProfileP1.Data;
using StudentProfileP1.Models;
using StudentProfileP1.Repository.RepositoryInterface;

namespace StudentProfileP1.Repository.RepositoryImplementation
{
    public class StudentsRepository:IStudentsRepository
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentsRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> students = new List<Student>();
            students = await _studentDbContext.StudentsP1.ToListAsync();
            return students;
        }

        public async Task<Boolean> CreateStudentAsync(Student model, CancellationToken cancellationToken = default)
        {
            Boolean isCreate = false;
            int count = 0;
            var exists = await _studentDbContext.StudentsP1.AnyAsync(x => x.Email.Trim().ToLower() == model.Email.Trim().ToLower());

            if (cancellationToken.IsCancellationRequested == false)
            {
                if (!exists)
                {
                    await _studentDbContext.StudentsP1.AddAsync(model);
                    count = await _studentDbContext.SaveChangesAsync();
                    isCreate = true;
                }
            }
            return isCreate;
        }
    }
}
