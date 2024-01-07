using Application.Command.Students;
using Application.Queries.Students;
using Application.DTO.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); ;
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            return View(new StudentFullDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentFullDTO student)
        {            
            var validator = new StudentValidator();
            var result = validator.Validate(student);      
            if (result.IsValid)
            {
                await _mediator.Send(new CreateStudentCommand(student));
                return RedirectToAction("List");   
            }
            result.Errors.ForEach(error => ModelState.AddModelError(error.PropertyName, error.ErrorMessage));   
            return View(student); 
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllStudentsQuery());
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StudentFullDTO student)
        {
            var validator = new StudentValidator();
            var result = validator.Validate(student);
            if (result.IsValid)
            {
                await _mediator.Send(new UpdateStudentCommand(student));
                return RedirectToAction("Edit");
            }
            result.Errors.ForEach(error => ModelState.AddModelError(error.PropertyName, error.ErrorMessage));
            return View(student);            
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteStudentCommand(id));
            return RedirectToAction("List");
        }
    }
}
