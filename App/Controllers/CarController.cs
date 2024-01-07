using Application.Command.Cars;
using Application.DTO.Cars;
using Application.Queries.Cars;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class CarController : Controller
    {     
            private readonly IMediator _mediator;

            public CarController(IMediator mediator)
            {
                _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); ;
            }

            [HttpGet]
            public IActionResult Add()
            {
                return View(new CarFullDTO());
            }

            [HttpPost]
            public async Task<IActionResult> Add(CarFullDTO car)
            {
                var validator = new CarValidator();
                var result = validator.Validate(car);
                if (result.IsValid)
                {
                    await _mediator.Send(new CreateCarCommand(car));
                    return RedirectToAction("List");
                }

                result.Errors.ForEach(error => ModelState.AddModelError(error.PropertyName, error.ErrorMessage));
                return View(car);
            }

            [HttpGet]
            public async Task<IActionResult> List()
            {
                var result = await _mediator.Send(new GetAllCarsQuery());
                return View(result);
            }

            [HttpGet]
            public async Task<IActionResult> Edit(int id)
            {
                var result = await _mediator.Send(new GetCarByIdQuery(id));
                return View(result);
            }
            [HttpPost]
            public async Task<IActionResult> Edit(CarFullDTO car)
            {
                var validator = new CarValidator();
                var result = validator.Validate(car);
                if (result.IsValid)
                {
                    await _mediator.Send(new UpdateCarCommand(car));
                    return RedirectToAction("Edit");
                }

                result.Errors.ForEach(error => ModelState.AddModelError(error.PropertyName, error.ErrorMessage));
                return View(car);
            }

            public async Task<IActionResult> Delete(int id)
            {
                var result = await _mediator.Send(new DeleteCarCommand(id));
                return RedirectToAction("List");
            }
        }
}
