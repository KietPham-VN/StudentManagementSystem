using FluentValidation;
using StudentManagementSystem.Application.DTOs.StudentDTO;
using StudentManagementSystem.Infrastructures;

namespace StudentManagementSystem.Application.ModelValidation
{
    public class StudentCreateModelValidator : AbstractValidator<StudentCreateModel>
    {
        private readonly IApplicationDbContext _dbcontext;

        public StudentCreateModelValidator(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Tên không được để trống")
                .Length(1, 255).WithMessage("Tên không được quá 255 ký tự");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Họ không được để trống")
                .Length(1, 255).WithMessage("Họ không được quá 255 ký tự");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Ngày sinh không được để trống")
                .LessThan(DateTime.Now).WithMessage("Ngày sinh phải nhỏ hơn ngày hiện tại");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Địa chỉ không được để trống");

            RuleFor(x => x.SchoolId)
                .NotEmpty().WithMessage("Trường học không được để trống");
        }
    }
}