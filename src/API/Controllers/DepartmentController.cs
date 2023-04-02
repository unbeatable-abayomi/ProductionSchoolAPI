using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using DLL.DBContext;
using DLL.Model;
using DLL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{   
    // [ApiVersion( "1.0" )]
    // [ApiController]
    // [Route("api/v{version:apiVersion}/[controller]")]
    public class DepartmentController : MainApiController
    {
        private readonly IDepartmentService _departmentservice;
        public DepartmentController(IDepartmentService departmentservice)
        {
            _departmentservice = departmentservice;
        }
        // GET
        // [HttpGet]
        // public IActionResult GetAll()
        // {
        //     return Ok(DepartmentStatic.GetAllDepartments());
        // }
        
        // GET
        [HttpGet]
        public async Task<IActionResult>  GetAll()
        {
            return Ok(await _departmentservice.GetAllAsync());
        }


        // [HttpGet("{code}")]
        // public IActionResult GetA(string code)
        // {
        //     return Ok(DepartmentStatic.GetADepartment(code));
        // }
        
        
        [HttpGet("{code}")]
        public async Task<IActionResult> GetA(string code)
        {
            return Ok(await _departmentservice.GetAAsync(code));
        }
        
        
        // [HttpPost]
        // public IActionResult Insert(Department department)
        // {
        //
        //     
        //     return Ok(DepartmentStatic.InsertDepartment(department));
        // }
        
        
        [HttpPost]
        public async Task<IActionResult> Insert(Department department)
        {

            return Ok(await _departmentservice.InsertAsync(department));
            // return Ok(DepartmentStatic.InsertDepartment(department));
        }
        
        // [HttpPut("{code}")]
        // public IActionResult Update(string code,Department department)
        // {
        //     return Ok(DepartmentStatic.UpdateDepartment(code,department));
        // }
        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string code,Department department)
        {
            return Ok(await _departmentservice.UpdateAsync(code, department));
        }
        
         
        
        // [HttpDelete("{code}")]
        // public IActionResult Delete(string code)
        // {
        //     return Ok(DepartmentStatic.DeleteDepartment(code));
        // }
        
        
                
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            return Ok(await _departmentservice.DeleteAsync(code));
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