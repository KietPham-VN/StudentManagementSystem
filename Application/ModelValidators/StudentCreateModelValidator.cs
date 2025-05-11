namespace Application.ModelValidators
{
    public class StudentCreateModelValidator : AbstractValidator<StudentCreateModel>
    {
        private readonly IApplicationDbContext _context;

        public StudentCreateModelValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Tên không được để trống")
                .Length(1, 255).WithMessage("Tên không được quá 255 ký tự")
                .Must(DoesNotExist).WithMessage("Tên đã tồn tại trong hệ thống");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Họ không được để trống")
                .Length(1, 255).WithMessage("Họ không được quá 255 ký tự");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Ngày sinh không được để trống")
                .LessThan(DateTime.Now).WithMessage("Ngày sinh phải nhỏ hơn ngày hiện tại");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Địa chỉ không được để trống");
            //.SetValidator(new AddressValidator())
            //.WithMessage("Địa chỉ không hợp lệ");

            RuleFor(x => x.SchoolId)
                .NotEmpty().WithMessage("Trường học không được để trống");
        }

        private bool DoesNotExist(string firstName)
        {
            return !_context.Students.Any(x => x.FirstName == firstName);
        }
    }
}