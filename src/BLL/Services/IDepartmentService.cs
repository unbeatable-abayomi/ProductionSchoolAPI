﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Request;
using DLL.Model;
using DLL.Repositories;
using Utility.Exceptions;

namespace BLL.Services
{
    // public interface IDepartmentService 
    // {
    //     Task<Department> InsertAsync(DepartmentInsertRequestViewModel request);
    //     Task<List<Department>> GetAllAsync();
    //     Task<Department> DeleteAsync(string code);
    //     Task<Department> UpdateAsync(string code,Department department);
    //     Task<Department> GetAAsync(string code);
    //     Task<bool> IsCodeExists(string code);
    //     Task<bool> IsNameExists(string name);
    //
    // }
    //
    // public class DepartmentService  : IDepartmentService
    // {
    //     private readonly IDepartmentRepository _departmentRepository;
    //
    //     public DepartmentService(IDepartmentRepository departmentRepository)
    //     {
    //         _departmentRepository = departmentRepository;
    //     }
    //     public async Task<Department> InsertAsync(DepartmentInsertRequestViewModel request)
    //     {
    //         Department dept = new Department();
    //         dept.Code = request.Code;
    //         dept.Name = request.Name;
    //         return await _departmentRepository.InsertAsync(dept);
    //     }
    //
    //     public async Task<List<Department>> GetAllAsync()
    //     {
    //         return await _departmentRepository.GetAllAsync();
    //     }
    //
    //     public async Task<Department> DeleteAsync(string code)
    //     {
    //         var department = await _departmentRepository.GetAAsync(code);
    //         if (department == null)
    //         {
    //             //throw new Exception("department not found");
    //           throw  new ApplicationValidationException("department not found");
    //         }
    //         //return await _departmentRepository.DeleteAsync(department.Code);
    //         if (await _departmentRepository.DeleteAsync(department))
    //         {
    //             return department;
    //         };
    //         //throw new Exception("Encountered Error While Deleting Data");
    //         throw  new ApplicationValidationException("Encountered Error While Deleting Data");
    //     }
    //
    //     public async Task<Department> UpdateAsync(string code, Department department)
    //     {
    //         var dept = await _departmentRepository.GetAAsync(code);
    //         if (dept == null)
    //         {
    //             throw new Exception("department not found to update");
    //         }
    //
    //         if (!string.IsNullOrWhiteSpace(department.Code))
    //         {
    //             var alreadyExistsCode =await _departmentRepository.FindByCode(department.Code);
    //             if (alreadyExistsCode != null)
    //             {
    //                 throw  new ApplicationValidationException("Your Updated Code already in our system");
    //             }
    //             dept.Code = department.Code;
    //         }
    //       
    //
    //         
    //         if (!string.IsNullOrWhiteSpace(department.Name))
    //         {
    //             var alreadyExistsCode =await _departmentRepository.FindByName(department.Name);
    //             if (alreadyExistsCode != null)
    //             {
    //                 throw  new ApplicationValidationException("Your Updated Name already in our system");
    //             }
    //             dept.Name = department.Name;
    //
    //         }
    //
    //          if (await _departmentRepository.UpdateAsync(dept))
    //          {
    //              return dept;
    //          } ;
    //          throw  new ApplicationValidationException("Couldn't Update your department ");
    //     }
    //
    //     public async Task<Department> GetAAsync(string code)
    //     {
    //         var department =  await _departmentRepository.GetAAsync(code);
    //         if (department == null)
    //         {
    //             throw new ApplicationValidationException("Department Not found");
    //
    //         }
    //
    //         return department;
    //     }
    //
    //     public async Task<bool> IsCodeExists(string code)
    //     {
    //         var department = await _departmentRepository.FindByCode(code);
    //         if (department == null)
    //         {
    //             return true;
    //         }
    //
    //         return false;
    //     }
    //
    //     public async Task<bool> IsNameExists(string name)
    //     {
    //         var department = await _departmentRepository.FindByName(name);
    //         if (department == null)
    //         {
    //             return true;
    //         }
    //
    //         return false;
    //     }
    // }
    
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
            await _departmentRepository.CreateAsync(dept);
            if (await _departmentRepository.SaveCompletedAsync())
            {
                return dept;
            }
            throw  new ApplicationValidationException("department insert has some issues");

        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _departmentRepository.GetList();
        }

        public async Task<Department> DeleteAsync(string code)
        {
            var department = await _departmentRepository.FindSingleAsync(x => x.Code == code);
            if (department == null)
            {
                //throw new Exception("department not found");
              throw  new ApplicationValidationException("department not found");
            }

            _departmentRepository.Delete(department);
            //return await _departmentRepository.DeleteAsync(department.Code);
            if (await _departmentRepository.SaveCompletedAsync() )
            {
                return department;
            };
            //throw new Exception("Encountered Error While Deleting Data");
            throw  new ApplicationValidationException("Encountered Error While Deleting Data");
        }

        public async Task<Department> UpdateAsync(string code, Department department)
        {
            var dept = await _departmentRepository.FindSingleAsync(x => x.Code == code);
            if (dept == null)
            {
                throw new Exception("department not found to update");
            }

            if (!string.IsNullOrWhiteSpace(department.Code))
            {
                var alreadyExistsCode = await _departmentRepository.FindSingleAsync(x => x.Code == department.Code);
                if (alreadyExistsCode != null)
                {
                    throw  new ApplicationValidationException("Your Updated Code already in our system");
                }
                dept.Code = department.Code;
            }
          

            
            if (!string.IsNullOrWhiteSpace(department.Name))
            {
                var alreadyExistsCode =await _departmentRepository.FindSingleAsync(x => x.Name == department.Name);
                if (alreadyExistsCode != null)
                {
                    throw  new ApplicationValidationException("Your Updated Name already in our system");
                }
                dept.Name = department.Name;

            }
             _departmentRepository.Update(dept);
             if (await _departmentRepository.SaveCompletedAsync())
             {
                 return dept;
             } ;
             throw  new ApplicationValidationException("Couldn't Update your department ");
        }

        public async Task<Department> GetAAsync(string code)
        {
            var department =  await _departmentRepository.FindSingleAsync(x => x.Code == code);
            if (department == null)
            {
                throw new ApplicationValidationException("Department Not found");

            }

            return department;
        }

        public async Task<bool> IsCodeExists(string code)
        {
            var department = await _departmentRepository.FindSingleAsync(x => x.Code == code);
            if (department == null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> IsNameExists(string name)
        {
            var department = await _departmentRepository.FindSingleAsync(x => x.Name == name);
            if (department == null)
            {
                return true;
            }

            return false;
        }
    }
}