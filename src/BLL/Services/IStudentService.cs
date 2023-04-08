using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Request;
using DLL.Model;
using DLL.Repositories;

namespace BLL.Services
{
    public interface IStudentService
    {
        Task<Student> InsertAsync(StudentInsertRequestViewModel request);
        Task<List<Student>> GetAllAsync();
        Task<Student> DeleteAsync(string email);
        Task<Student> UpdateAsync(string email,Student student);
        Task<Student> GetAAsync(string email);
        Task<bool> IsEmailExists(string email);
        Task<bool> IsNameExists(string name);
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> InsertAsync(StudentInsertRequestViewModel request)
        {
            var student = new Student();
            student.Email = request.Email;
            student.Name = request.Name;
            return await _studentRepository.InsertAsync(student);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> DeleteAsync(string email)
        {
            return await _studentRepository.DeleteAsync(email);
        }

        public async Task<Student> UpdateAsync(string email, Student student)
        {
            return await _studentRepository.UpdateAsync(email, student);
        }

        public async Task<Student> GetAAsync(string email)
        {
            return await _studentRepository.GetAAsync(email);
        }

        public async Task<bool> IsEmailExists(string email)
        {
            var student = await _studentRepository.FindByEmail(email);
            if (student == null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> IsNameExists(string name)
        {
            var student = await _studentRepository.FindByName(name);
            if (student == null)
            {
                return true;
            }

            return false;
        }
    }
    
}