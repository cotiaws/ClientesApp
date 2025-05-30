using ClientesApp.Domain.Commands;
using ClientesApp.Domain.Interfaces.Services;
using ClientesApp.Domain.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController(IClienteDomainService clienteDomainService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ClienteQuery), 201)]
        public async Task<IActionResult> Post([FromBody] ClienteCreateCommand command)
        {
            var result = await clienteDomainService.Create(command);
            return StatusCode(201, result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ClienteQuery), 200)]
        public async Task<IActionResult> Put([FromBody] ClienteUpdateCommand command)
        {
            var result = await clienteDomainService.Update(command);
            return StatusCode(200, result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ClienteQuery), 200)]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var result = await clienteDomainService.Delete(new ClienteDeleteCommand { Id = id });
            return StatusCode(200, result);
        }

        [HttpGet("{page}/{pageSize}")]
        [ProducesResponseType(typeof(List<ClienteQuery>), 200)]
        public async Task<IActionResult> Get(int page, int pageSize)
        {
            if (!(page >= 1 && pageSize <= 25))
                return StatusCode(400, new { message = "O parâmetro 'page' deve ser maior ou igual a 1 e o 'pageSize' deve ser menor ou igual a 25." });

            var result = await clienteDomainService.GetAll(page, pageSize);

            if (!result.Any()) return NoContent();

            return StatusCode(200, result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteQuery), 200)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await clienteDomainService.GetById(id);

            if (result == null) return NoContent();

            return StatusCode(200, result);
        }

    }
}
