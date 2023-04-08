using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Request;
using DLL.Model;
using DLL.Repositories;
using Utility.Exceptions;

namespace BLL.Services
{
    public interface IStudentService
    {
        Task<Student> InsertAsync(Student student);
        Task<List<Student>> GetAllAsync();
        Task<Student> DeleteAsync(string email);
        Task<Student> UpdateAsync(string email,Student student);
        Task<Student> GetAAsync(string email);
        // Task<bool> IsEmailExists(string email);
        // Task<bool> IsNameExists(string name);
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> InsertAsync(Student student)
        {

             await _studentRepository.CreateAsync(student);
             if (await _studentRepository.SaveCompletedAsync())
             {
                 return student;
             }
             throw  new ApplicationValidationException("student insert has some issues");

        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetList();
        }

        public async Task<Student> DeleteAsync(string email)
        {
            var dbStudent = await _studentRepository.FindSingleAsync(x => x.Email == email);
            if (dbStudent == null)
            {
                throw  new ApplicationValidationException("student not found");
            }
            _studentRepository.Delete(dbStudent);
            if (await _studentRepository.SaveCompletedAsync())
            {
                return dbStudent;
            }
            throw  new ApplicationValidationException("student delete has some issues");

        }

        public async Task<Student> UpdateAsync(string email, Student student)
        {
           var dbStudent = await _studentRepository.FindSingleAsync(x => x.Email == email);
           if (dbStudent == null)
           {
               throw  new ApplicationValidationException("student not found");
           }

           dbStudent.Name = student.Name;
           
            _studentRepository.Update(dbStudent);
            if (await _studentRepository.SaveCompletedAsync())
            {
                return dbStudent;
            }
            throw  new ApplicationValidationException("student update has some issues");
            
         
        }

        public async Task<Student> GetAAsync(string email)
        {
            return await _studentRepository.FindSingleAsync(x => x.Email == email);
        }

        // public async Task<bool> IsEmailExists(string email)
        // {
        //     var student = await _studentRepository.FindByEmail(email);
        //     if (student == null)
        //     {
        //         return true;
        //     }
        //
        //     return false;
        // }
        //
        // public async Task<bool> IsNameExists(string name)
        // {
        //     var student = await _studentRepository.FindByName(name);
        //     if (student == null)
        //     {
        //         return true;
        //     }
        //
        //     return false;
        // }
    }
    
}