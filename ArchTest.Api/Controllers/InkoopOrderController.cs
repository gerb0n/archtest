using ArchTest.Core.Extensions.CqrsLite;
using ArchTest.Domain;
using ArchTest.Domain.Commands.Inkoop;
using CQRSlite.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ArchTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InkoopOrderController : ControllerBase
    {
        private readonly ILogger<InkoopOrderController> _logger;
        private readonly ICommandSender _commandSender;
        private readonly ArchTestContext _dbContext;

        public InkoopOrderController(ILogger<InkoopOrderController> logger, ICommandSender commandSender, ArchTestContext dbContext)
        {
            _logger = logger;
            _commandSender = commandSender;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var command = new CreateInkoopOrder(
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                1500);

            await _commandSender.ValidateAndSend(command);

            return Ok();
        }

        [HttpPost("{inkoopOrderId}/addlaadplaats")]
        public async Task<IActionResult> AddLaadPlaats([FromRoute] Guid inkoopOrderId)
        {
            var command = new AddLaadPlaats(
                inkoopOrderId,
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid());

            await _commandSender.Send(command);
            return Ok();
        }

        [HttpPost("{inkoopOrderId}/plaats/{inkoopOrderPlaatsId}/verlaadbeurt-aanvragen")]
        public async Task<IActionResult> VerlaadBeurtAanvragen([FromRoute] Guid inkoopOrderId, [FromRoute] Guid inkoopOrderPlaatsId)
        {
            var command = new VerlaadBeurtAanvragen(
                inkoopOrderId,
                inkoopOrderPlaatsId,
                Guid.NewGuid(),
                DateTime.UtcNow,
                "bijzonderheden");

            await _commandSender.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _dbContext.InkoopOrders
                .Include(o => o.LaadPlaatsen).ThenInclude(p => p.VerlaadBeurt)
                .ToListAsync();
            return Ok(orders);
        }

        [HttpGet("read")]
        public async Task<IActionResult> GetRead()
        {
            var orders = await _dbContext.OrderItems
                .Include(o => o.LaadPlaatsen)
                .ToListAsync();
            return Ok(orders);
        }
    }
}
