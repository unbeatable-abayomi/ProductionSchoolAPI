using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.DBContext;
using DLL.Model;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repositories
{
    // public interface IStudentRepository
    // {
    //     Task<Student> InsertAsync(Student student);
    //     Task<List<Student>> GetAllAsync();
    //     Task<Student> DeleteAsync(string email);
    //     Task<Student> UpdateAsync(string email,Student student);
    //     Task<Student> GetAAsync(string email);
    //     Task <Student> FindByEmail(string email);
    //     Task <Student> FindByName(string name);
    // }
    //
    // public class StudentRepository : IStudentRepository
    // {
    //     private readonly ApplicationDbContext _applicationDbContext;
    //     public StudentRepository(ApplicationDbContext applicationDbContext)
    //     {
    //         _applicationDbContext = applicationDbContext;
    //     }
    //      
    //     public async Task<Student> InsertAsync(Student student)
    //     {
    //         await _applicationDbContext.Students.AddAsync(student);
    //         await _applicationDbContext.SaveChangesAsync();
    //         return student;
    //     }
    //
    //     public async Task<List<Student>> GetAllAsync()
    //     {
    //         return await _applicationDbContext.Students.ToListAsync();
    //     }
    //
    //     public async Task<Student> DeleteAsync(string email)
    //     {
    //         var student = await _applicationDbContext.Students.FirstOrDefaultAsync(s => s.Email == email);
    //          _applicationDbContext.Students.Remove(student);
    //          await _applicationDbContext.SaveChangesAsync();
    //          return student;
    //
    //     }
    //
    //     public async Task<Student> UpdateAsync(string email, Student student)
    //     {
    //         var foundStudent = await _applicationDbContext.Students.FirstOrDefaultAsync(s => s.Email == email);
    //         foundStudent.Name = student.Name;
    //         _applicationDbContext.Students.Update(foundStudent);
    //         await _applicationDbContext.SaveChangesAsync();
    //         return foundStudent;
    //
    //     }
    //
    //     public async Task<Student> GetAAsync(string email)
    //     {
    //         var student = await _applicationDbContext.Students.FirstOrDefaultAsync(s => s.Email == email);
    //         return student;
    //
    //     }
    //
    //     public async Task<Student> FindByEmail(string email)
    //     {
    //         return await _applicationDbContext.Students.FirstOrDefaultAsync(s => s.Email == email);
    //     }
    //
    //     public async Task<Student> FindByName(string name)
    //     {
    //         return await _applicationDbContext.Students.FirstOrDefaultAsync(s => s.Name == name);
    //     }
    // }
      public interface IStudentRepository : IRepositoryBase<Student>
    {

    }
    
    public class StudentRepository : RepositoryBase<Student>,IStudentRepository
    {
        //private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context) :base(context)
        {
            //_context = context;
        }

    }
}