using Microsoft.AspNetCore.Mvc;
using ToDoApp.ViewModels;
using MediatR;
using UseCases.Handlers.ToDo.Commands.CreateToDo;
using UseCases.Handlers.ToDo.Queries.GetToDoCollectionByStatus;
using UseCases.Enums;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IMediator _mediator;

        public ToDoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddViewModel viewModel)
        {
            var command = new CreateToDoCommand()
            {
                Title = viewModel.Title,
            };

            await _mediator.Send(command);

            return View();
        }
    }
}
