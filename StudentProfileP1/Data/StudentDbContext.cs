using Microsoft.EntityFrameworkCore;
using StudentProfileP1.Models;

namespace StudentProfileP1.Data
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> StudentsP1 { get; set; }
    }
}
