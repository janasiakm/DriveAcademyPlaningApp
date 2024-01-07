using Application.DTO.Timetable;
using FluentValidation;

    public class TimetableValidator : AbstractValidator<TimetableAdd>
    {
    public TimetableValidator()
    {
        RuleFor(x => x.Date)
            .NotNull().WithMessage("Proszę wybrać datę")
            .NotEmpty().WithMessage("Proszę wybrać datę")
            .Must(date => date != null && date > DateTime.Now).WithMessage("Nie możesz planować przeszłości");
            
        RuleFor(x => x.NumbersOfHours)
            .NotNull().WithMessage("Proszę wybrać liczbę godzin.")
            .NotEqual(0).WithMessage("Proszę wybrać liczbę godzin."); 

        RuleFor(x => x.Category)
            .NotNull().WithMessage("Proszę wybrać Kategorie")
            .NotEqual("0").WithMessage("Proszę wybrać Kategorie") ;

        RuleFor(x => x.InstructorId)
            .NotNull().WithMessage("Proszę wybrać instruktora")
            .NotEqual(0).WithMessage("Proszę wybrać instruktora");

        RuleFor(x => x.StudentId)
            .NotNull().WithMessage("Proszę wybrać Kursanta")
            .NotEqual(0).WithMessage("Proszę wybrać Kursanta");

        RuleFor(x => x.CarId)
            .NotNull().WithMessage("Proszę wybrać samochód")
            .NotEqual(0).WithMessage("Proszę wybrać samochód");
    }
}

