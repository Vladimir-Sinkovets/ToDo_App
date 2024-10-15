using Microsoft.AspNetCore.Mvc;
using ToDoApp.ViewModels;
using MediatR;
using UseCases.Handlers.ToDo.Commands.CreateToDo;
using UseCases.Handlers.ToDo.Queries.GetToDoCollectionByStatus;
using UseCases.Enums;
using UseCases.Handlers.ToDo.Commands.DeleteToDo;

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

        [HttpGet]
        public async Task<IActionResult> ActiveList()
        {
            var query = new GetToDoCollectionByStatusQuery()
            {
                Status = ToDoStatus.Active,
            };

            var dto = await _mediator.Send(query);

            var viewModel = new ActiveListViewModel()
            {
                ToDos = dto.ToDos.Select(t => new ToDoViewModel()
                {
                    Created = t.Created,
                    Id = t.Id,
                    Title = t.Title,
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteToDoCommand()
            {
                ToDoId = Guid.Parse(id),
            };

            await _mediator.Send(command);

            return RedirectToAction(nameof(ActiveList));
        }
    }
}
