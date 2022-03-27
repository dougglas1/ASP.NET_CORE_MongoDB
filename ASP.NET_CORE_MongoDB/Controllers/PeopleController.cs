using ASP.NET_CORE_MongoDB.Contracts.Commands;
using ASP.NET_CORE_MongoDB.Contracts.Filters;
using ASP.NET_CORE_MongoDB.Handlers;
using ASP.NET_CORE_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ASP.NET_CORE_MongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        public PeopleController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IPeopleService service)
        {
            var result = await service.GetAllAsync();
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetById([FromServices] IPeopleService service, [FromRoute] Guid id)
        {
            var result = await service.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet, Route("Expression")]
        public async Task<IActionResult> GetToExpression([FromServices] IPeopleService service, [FromQuery] PeopleFilter filter)
        {
            var result = await service.GetToExpressionAsync(filter);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet, Route("Pagination")]
        public async Task<IActionResult> GetPaginated([FromServices] IPeopleService service, [FromQuery] PeopleFilter filter)
        {
            var result = await service.GetPaginatedAsync(filter);
            return result is null ? NotFound() : Ok(result);
        }
        
        [HttpGet, Route("Exist")]
        public async Task<IActionResult> Exist([FromServices] IPeopleService service, [FromQuery] Guid id)
        {
            var result = await service.ExistAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromServices] IPeopleCreateCommandHandler handler, [FromBody] PeopleCreateCommand command)
        {
            var result = await handler.ExecuteAsync(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromServices] IPeopleUpdateCommandHandler handler, [FromBody] PeopleUpdateCommand command)
        {
            var result = await handler.ExecuteAsync(command);
            return Ok(result);
        }
        
        [HttpDelete, Route("{Id}")]
        public async Task<IActionResult> Remove([FromServices] IPeopleRemoveCommandHandler handler, [FromRoute] PeopleRemoveCommand command)
        {
            await handler.ExecuteAsync(command);
            return Ok();
        }

        [HttpDelete, Route("Logic/{Id}")]
        public async Task<IActionResult> RemoveLogic([FromServices] IPeopleRemoveLogicCommandHandler handler, [FromRoute] PeopleRemoveCommand command)
        {
            await handler.ExecuteAsync(command);
            return Ok();
        }
    }
}
