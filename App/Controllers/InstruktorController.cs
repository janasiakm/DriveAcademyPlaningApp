using Application.Command.Instructors;
using Application.DTO.Instructors;
using Application.Queries.Instructors;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace App.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IMediator _mediator;

        public InstructorController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new InstructorFullDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Add(InstructorFullDTO instructor)
        {
            var validator = new InstructorValidator();
            var result = validator.Validate(instructor);
            if (result.IsValid)
            {
                await _mediator.Send(new CreateInstructorCommand(instructor));
                return RedirectToAction("List");
            }

            result.Errors.ForEach(error => ModelState.AddModelError(error.PropertyName, error.ErrorMessage));
            return View(instructor);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllInstructorsQuery());
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _mediator.Send(new GetInstructorByIdQuery(id));
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(InstructorFullDTO instructor)
        {
            var validator = new InstructorValidator();
            var result = validator.Validate(instructor);
            if (result.IsValid)
            {
                await _mediator.Send(new UpdateInstructorCommand(instructor));
                return RedirectToAction("Edit");
            }

            result.Errors.ForEach(error => ModelState.AddModelError(error.PropertyName, error.ErrorMessage));
            return View(instructor);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteInstructorCommand(id));
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Category(int id)
        {
            var result = await _mediator.Send(new GetCategoryInstructorQuery(id));
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Category(InstructorWithCategoryDTO body)
        {
            await _mediator.Send(new UpdateCategoryInstructorCommand(body));
            return RedirectToAction("Category", body.InstructorId);
        }
    }
}


