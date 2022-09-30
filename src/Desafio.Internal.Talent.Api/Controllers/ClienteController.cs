using Desafio.Internal.Talent.Api.Data;
using Desafio.Internal.Talent.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Internal.Talent.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClienteController : Controller
    {
        private readonly ClientAPIDbContext dbContext;
        public ClienteController(ClientAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCliente()
        {
            return Ok(await dbContext.Cliente.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetClienteById(
            [FromRoute] Guid id)
        {
            Cliente? client = await dbContext.Cliente.FindAsync(id);

            if(client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> AddCliente(AddClienteRequest addClient)
        {
            Cliente cliente = new Cliente()
            {
                Id = new Guid(),
                FirstName = addClient.FirstName,
                SecondName = addClient.SecondName,
                Born = addClient.Born,
                Age = addClient.Age,
            };

            await dbContext.Cliente.AddAsync(cliente);
            await dbContext.SaveChangesAsync();

            return Ok(cliente);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateClient(
            [FromRoute] Guid id, UpdateCLienteRequest updateCLienteRequest)
        {
            Cliente? cliente = await dbContext.Cliente.FindAsync(id);

            if(cliente != null)
            {
                cliente.FirstName = updateCLienteRequest.FirstName;
                cliente.SecondName = updateCLienteRequest.SecondName;
                cliente.Age = updateCLienteRequest.Age;
                cliente.Born = updateCLienteRequest.Born;

                await dbContext.SaveChangesAsync();

                return Ok(cliente);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCliente([FromRoute] Guid id)
        {
            Cliente cliente = await dbContext.Cliente.FindAsync(id);

            if (cliente != null)
            {
                dbContext.Cliente.Remove(cliente);
                await dbContext.SaveChangesAsync();
            }

            return NotFound();
        }
    }   
}