using BLL.Request;
using BLL.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class BLLDependency
    {
        public static void ALLDependency(IServiceCollection services, IConfiguration configuration)
        {
           
            
            
            //repository dependency
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IStudentService, StudentService>();
            //nw===e
            AllFluentValidationDepedency(services);
        }

        private static void AllFluentValidationDepedency(IServiceCollection services)
        {
            services
                .AddTransient<IValidator<DepartmentInsertRequestViewModel>,
                    DepartmentInsertRequestViewModelValidator>();
            services
                .AddTransient<IValidator<StudentInsertRequestViewModel>,
                    StudentInsertRequestViewModelValidator>();
        }
    }
}