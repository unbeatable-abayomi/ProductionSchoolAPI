using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Request;
using DLL.Model;
using DLL.Repositories;

namespace BLL.Services
{
    public interface IDepartmentService 
    {
        Task<Department> InsertAsync(DepartmentInsertRequestViewModel request);
        Task<List<Department>> GetAllAsync();
        Task<Department> DeleteAsync(string code);
        Task<Department> UpdateAsync(string code,Department department);
        Task<Department> GetAAsync(string code);
        Task<bool> IsCodeExists(string code);
        Task<bool> IsNameExists(string name);

    }

    public class DepartmentService  : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<Department> InsertAsync(DepartmentInsertRequestViewModel request)
        {
            Department dept = new Department();
            dept.Code = request.Code;
            dept.Name = request.Name;
            return await _departmentRepository.InsertAsync(dept);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }

        public async Task<Department> DeleteAsync(string code)
        {
            return await _departmentRepository.DeleteAsync(code);
        }

        public async Task<Department> UpdateAsync(string code, Department department)
        {
            return await _departmentRepository.UpdateAsync(code, department);
        }

        public async Task<Department> GetAAsync(string code)
        {
            return await _departmentRepository.GetAAsync(code);
        }

        public async Task<bool> IsCodeExists(string code)
        {
            var department = await _departmentRepository.FindByCode(code);
            if (department == null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> IsNameExists(string name)
        {
            var department = await _departmentRepository.FindByName(name);
            if (department == null)
            {
                return true;
            }

            return false;
        }
    }
}