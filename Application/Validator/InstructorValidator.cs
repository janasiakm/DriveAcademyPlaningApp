using Application.DTO.Instructors;
using FluentValidation;

public class InstructorValidator : AbstractValidator<InstructorFullDTO>
{
    public InstructorValidator()
    {
        RuleFor(x => x.FirstName)
            .MinimumLength(3).WithMessage("Minimum to 3 znaki")
            .MaximumLength(100).WithMessage("Maksymalna dłogość to 100 znaków")
            .NotNull().WithMessage("To pole jest wymagane!");

        RuleFor(x => x.LastName)
            .MinimumLength(3).WithMessage("Minimum to 3 znaki")
            .MaximumLength(100).WithMessage("Maksymalna dłogość to 100 znaków")
            .NotNull().WithMessage("To pole jest wymagane!");

        RuleFor(x => x.DateOfBirth)            
            .NotNull().WithMessage("Proszę wybrać datę")
            .NotEmpty().WithMessage("Proszę wybrać datę")
            .Must(date => date != null && date.AddYears(18) < DateTime.Now).WithMessage("Instruktor musi mieć wiecej jak 18 lat");

        RuleFor(x => x.IdNumber)
            .MinimumLength(5).WithMessage("Minimum 5 znaków")
            .NotNull().WithMessage("To pole jest wymagane!");

        RuleFor(x => x.Email)
           .EmailAddress().WithMessage("Nie poprawny email");

        RuleFor(x => x.City)
            .MinimumLength(3).WithMessage("Za krótka wartość")
            .MaximumLength(30).WithMessage("Przekroczono ilość znaków")
            .NotNull().WithMessage("To pole jest wymagane!");

        RuleFor(x => x.Adress)
            .MinimumLength(3).WithMessage("Za krótka wartość")
            .MaximumLength(50).WithMessage("Przekroczono ilość znaków")
            .NotNull().WithMessage("To pole jest wymagane!");

        RuleFor(x => x.PostCode)
            .NotEmpty().WithMessage("Kod pocztowy jest wymagany.")
            .Matches(@"^\d{2}-\d{3}$").WithMessage("Nieprawidłowy format kodu pocztowego. Poprawny format to XX-XXX.");

        RuleFor(x => x.PhoneNr)
            .NotEmpty().WithMessage("Telefon jest wymagany.")
            .Matches(@"^\d{3}-\d{3}-\d{3}$").WithMessage("Nieprawidłowy format numeru telefonu. Poprawny format to XXX-XXX-XXX.");        
    }
}
