using BLL.Services;
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
        }
    }
}