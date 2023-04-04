using FluentValidation;

namespace BLL.Request
{
    public class DepartmentInsertRequestViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    
    public class DepartmentInsertRequestViewModelValidator : AbstractValidator<DepartmentInsertRequestViewModel> 
    {
        public DepartmentInsertRequestViewModelValidator() 
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(4).MaximumLength(25);
            RuleFor(x => x.Code).NotNull().NotEmpty().MinimumLength(3).MaximumLength(14);
        }
    }
}