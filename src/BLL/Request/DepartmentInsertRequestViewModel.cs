using System;
using System.Threading;
using System.Threading.Tasks;
using BLL.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Request
{
    public class DepartmentInsertRequestViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    
    public class DepartmentInsertRequestViewModelValidator : AbstractValidator<DepartmentInsertRequestViewModel>
    {
        private readonly IServiceProvider _serviceProvider;
        public DepartmentInsertRequestViewModelValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(4).MaximumLength(25).MustAsync(NameExist).WithMessage("Name already in Our system");
            RuleFor(x => x.Code).NotNull().NotEmpty().MinimumLength(3).MaximumLength(14).MustAsync(CodeExist).WithMessage("Code already in Our system");;
        }

        private async Task<bool> CodeExist(string code, CancellationToken arg2)
        {
            if (string.IsNullOrEmpty(code))
            {
                return  true;
            }

            var requiredService = _serviceProvider.GetRequiredService<IDepartmentService>();
            return await requiredService.IsCodeExists(code);
        }
        
        private async  Task<bool> NameExist (string name, CancellationToken arg2)
        {
            if (string.IsNullOrEmpty(name))
            {
                return  true;
            }

            var requiredService = _serviceProvider.GetRequiredService<IDepartmentService>();
            return await requiredService.IsNameExists(name);
        }
    }
}