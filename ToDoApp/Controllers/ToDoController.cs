using Microsoft.AspNetCore.Mvc;
using ToDoApp.ViewModels;
using MediatR;
using UseCases.Handlers.ToDo.Commands.CreateToDo;
using UseCases.Handlers.ToDo.Queries.GetToDoCollectionByStatus;
using UseCases.Enums;
using UseCases.Handlers.ToDo.Commands.DeleteToDo;
using UseCases.Handlers.ToDo.Commands.CompleteToDo;
using UseCases.Handlers.ToDo.Queries.GetToDoById;
using UseCases.Handlers.ToDo.Commands.UpdateToDo;
using UseCases.Exceptions;

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
            try
            {
                await _mediator.Send(command);
            }
            catch (ToDoNotFoundException)
            {
                return NotFound();
            }
            catch
            {
                throw;
            }

            return RedirectToAction(nameof(ActiveList));
        }

        [HttpPost]
        public async Task<IActionResult> Complete(string id)
        {
            var command = new CompleteToDoCommand()
            {
                ToDoId = Guid.Parse(id),
            };

            try
            {
                await _mediator.Send(command);
            }
            catch (ToDoNotFoundException)
            {
                return NotFound();
            }
            catch
            {
                throw;
            }

            return RedirectToAction(nameof(ActiveList));
        }

        [HttpGet]
        public async Task<IActionResult> CompletedList()
        {
            var query = new GetToDoCollectionByStatusQuery()
            {
                Status = ToDoStatus.Completed,
            };

            var dto = await _mediator.Send(query);

            var viewModel = new CompletedListViewModel()
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

        [HttpGet]
        public async Task<IActionResult> Edit(string id, string redirectUrl)
        {
            var query = new GetToDoByIdQuery()
            {
                ToDoId = Guid.Parse(id),
            };

            try
            {
                var dto = await _mediator.Send(query);

                var viewModel = new EditViewModel()
                {
                    Id = dto.Id,
                    Title = dto.Title,
                    RedirectUrl = redirectUrl
                };

                return View(viewModel);
            }
            catch (ToDoNotFoundException)
            {
                return NotFound();
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel viewModel)
        {
            var command = new UpdateToDoCommand()
            {
                ToDoId = viewModel.Id,
                Title = viewModel.Title,
            };

            try
            {
                await _mediator.Send(command);
            }
            catch (ToDoNotFoundException)
            {
                return NotFound();
            }
            catch
            {
                throw;
            }

            return Redirect(viewModel.RedirectUrl);
        }
    }
}
