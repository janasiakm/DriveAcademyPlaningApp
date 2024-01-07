using Application.DTO.Cars;
using FluentValidation;

public class CarValidator : AbstractValidator<CarFullDTO>
{
    public CarValidator()
    {
        RuleFor(x => x.Mark)
            .MinimumLength(3).WithMessage("Minimum to 3 znaki")
            .MaximumLength(25).WithMessage("Maksymalna dłogość to 25 znaków")
            .NotNull().WithMessage("To pole jest wymagane!");

        RuleFor(x => x.Model)
            .MinimumLength(3).WithMessage("Minimum to 3 znaki")
            .MaximumLength(25).WithMessage("Maksymalna dłogość to 25 znaków")
            .NotNull().WithMessage("To pole jest wymagane!");        

        RuleFor(x => x.RejestractionNumber)
            .MinimumLength(5).WithMessage("Za krótka wartość. Minumum 5 znaków")
            .MaximumLength(10).WithMessage("Przekroczono ilość znaków")
            .NotNull().WithMessage("To pole jest wymagane!");        
    }
}