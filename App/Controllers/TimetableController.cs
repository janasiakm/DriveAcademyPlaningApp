using Application.Command.Timetables;
using Application.DTO.Timetable;
using Application.Queries.Timetables;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class TimetableController : Controller
    {
        private readonly IMediator _mediator;
        public TimetableController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); ;
        }
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetTimetablesQuery());
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var Item1 = _mediator.Send(new GetDataForPlaningTimetableQuery());
            var Item2 = new TimetableAdd();
            var model = (Item1.Result, Item2);
            return View(model);
        }     
        

        [HttpPost]
        public async Task<IActionResult> Add(TimetablePlaning Item1, TimetableAdd Item2)
        {
            var validator = new TimetableValidator();
            var result = validator.Validate(Item2);

            if (result.IsValid)
            {
                await _mediator.Send(new CreateTimetableCommand(Item2));
                return RedirectToAction("List");
            }
            result.Errors.ForEach(error => ModelState.AddModelError(error.PropertyName, error.ErrorMessage));
            var Item = _mediator.Send(new GetDataForPlaningTimetableQuery());
            var model = (Item.Result, Item2);
            return View(model);            

        }


        public IActionResult Edit()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
           await _mediator.Send(new DeleteTimetableCommand(id));
           return RedirectToAction("List");       

        }
    }
}
