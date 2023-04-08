using System;
using System.Threading;
using System.Threading.Tasks;
using BLL.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Request
{
    public class StudentInsertRequestViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
    
    public class StudentInsertRequestViewModelValidator : AbstractValidator<StudentInsertRequestViewModel>
    {
        private readonly IServiceProvider _serviceProvider;
        public StudentInsertRequestViewModelValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(4).MaximumLength(25).MustAsync(NameExist).WithMessage("Name already in Our system");
            RuleFor(x => x.Email).NotNull().NotEmpty().MinimumLength(3).MaximumLength(14).MustAsync(EmailExist).WithMessage("Email already in Our system");;
        }

        private async Task<bool> EmailExist(string email, CancellationToken arg2)
        {
            if (string.IsNullOrEmpty(email))
            {
                return  true;
            }

            var requiredService = _serviceProvider.GetRequiredService<IStudentService>();
           // return await requiredService.IsEmailExists(email);
           return true;
        }
        
        private async  Task<bool> NameExist (string name, CancellationToken arg2)
        {
            if (string.IsNullOrEmpty(name))
            {
                return  true;
            }

            var requiredService = _serviceProvider.GetRequiredService<IStudentService>();
            //return await requiredService.IsNameExists(name);
            return true;

        }
    }
}