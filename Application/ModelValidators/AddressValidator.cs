namespace Application.ModelValiors
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street is required.")
                .Length(1, 255).WithMessage("Street must be between 1 and 255 characters.");
            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .WithMessage("ZipCode is required.");
        }
    }
}