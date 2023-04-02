using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using DLL.Model;
using DLL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // [ApiVersion( "1.0" )]
    // [ApiController]
    // [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentController : MainApiController
    {

        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET
        // [HttpGet]
        // public IActionResult GetAll()
        // {
        //     return Ok(StudentStatic.GetAllStudents());
        // }
        
        [HttpGet]
        public async  Task<IActionResult> GetAll()
        {
            return Ok(await _studentService.GetAllAsync());
        }

        //
        // [HttpGet("{email}")]
        // public IActionResult GetA(string email)
        // {
        //     return Ok(StudentStatic.GetAStudent(email));
        // }
        
        
        [HttpGet("{email}")]
        public async  Task<IActionResult> GetA(string email)
        {
            return Ok(await _studentService.GetAAsync(email));
        }
        
        //
        // [HttpPost]
        // public IActionResult Insert(Student student)
        // {
        //     return Ok(StudentStatic.InsertStudent(student));
        // }
        
                
        [HttpPost]
        public async  Task<IActionResult> Insert(Student student)
        {
            return Ok(await _studentService.InsertAsync(student));
        }
        //
        // [HttpPut("{email}")]
        // public IActionResult Update(string email,Student student)
        // {
        //     return Ok(StudentStatic.UpdateStudent(email,student));
        // }
        
        [HttpPut("{email}")]
        public async  Task<IActionResult> Update(string email,Student student)
        {
            return Ok(await _studentService.UpdateAsync(email,student));
        }
        
         
        //
        // [HttpDelete("{email}")]
        // public IActionResult Delete(string email)
        // {
        //     return Ok(StudentStatic.DeleteStudent(email));
        // }
        
                
        [HttpDelete("{email}")]
        public async  Task<IActionResult> Delete(string email)
        {
            return Ok(await _studentService.DeleteAsync(email));
        }
    }
    
    public  static class  StudentStatic
    {
        private static List<Student> AllStudents { get; set; } = new List<Student>();

        public static Student InsertStudent(Student student)
        {
            AllStudents.Add(student);
            return student;
        }


        public static List<Student> GetAllStudents()
        {
            return AllStudents;
        }

        public static Student GetAStudent(string email)
        {
            return AllStudents.FirstOrDefault(x => x.Email == email);
        }

        public static Student UpdateStudent(string email, Student stu)
        {
      
            // var department = GetADepartment(code);
            // department.Name = dept.Name;
            // return department;
            var student = new Student();
            foreach (var students in AllStudents)
            {
                if (students.Email == email)
                {
                    students.Name = stu.Name;
                    student = students;
                }
            }
            return student;
        }

        public static Student DeleteStudent(string email)
        {
            var student = AllStudents.FirstOrDefault(x => x.Email == email);
            
            AllStudents = AllStudents.Where(x => x.Email != student.Email).ToList();

            return student;
        }
    }
}