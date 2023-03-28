using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
     [ApiController]
     [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        // GET
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(DepartmentStatic.GetAllDepartments());
        }


        [HttpGet("{code}")]
        public IActionResult GetA(string code)
        {
            return Ok(DepartmentStatic.GetADepartment(code));
        }
        
        
        [HttpPost]
        public IActionResult Insert(Department department)
        {
            return Ok(DepartmentStatic.InsertDepartment(department));
        }
        
        [HttpPut("{code}")]
        public IActionResult Update(string code,Department department)
        {
            return Ok(DepartmentStatic.UpdateDepartment(code,department));
        }
        
         
        
        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            return Ok(DepartmentStatic.DeleteDepartment(code));
        }
    }
    
    public  static class  DepartmentStatic
    {
        private static List<Department> AllDepartments { get; set; } = new List<Department>();

        public static Department InsertDepartment(Department department)
        {
            AllDepartments.Add(department);
            return department;
        }


        public static List<Department> GetAllDepartments()
        {
            return AllDepartments;
        }

        public static Department GetADepartment(string code)
        {
            return AllDepartments.FirstOrDefault(x => x.Code == code);
        }

        public static Department UpdateDepartment(string code, Department dept)
        {
      
            // var department = GetADepartment(code);
            // department.Name = dept.Name;
            // return department;
            var department = new Department();
            foreach (var eachdept in AllDepartments)
            {
                if (eachdept.Code == code)
                {
                    eachdept.Name = dept.Name;
                    department = eachdept;
                }
            }
            return department;
        }

        public static Department DeleteDepartment(string code)
        {
            var department = AllDepartments.FirstOrDefault(x => x.Code == code);
            
            AllDepartments = AllDepartments.Where(x => x.Code != department.Code).ToList();

            return department;
        }
    }
}