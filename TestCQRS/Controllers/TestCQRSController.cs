using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestCQRS.DTO.Commands;
using TestCQRS.DTO.Queries;

namespace TestCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCQRSController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestCQRSController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllEmployeeQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetEmployeeByIdQuery() { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddEmployeeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EditEmployeeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("در انتخاب کارمند دقت نمائید!");
            }
            var response = await _mediator.Send(command);
            if (response == 0) return BadRequest("کارمند فوق یافت نشد!");
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteEmployeeCommand { Id = id }));
        }
    }
}
