using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project001.ServiceClient.Domain.Commands;
using Project001.ServiceClient.Domain.Commands.ClientCommands;
using Project001.ServiceClient.Domain.Entities;
using Project001.ServiceClient.Domain.Handlers.Interfaces;
using Project001.ServiceClient.Domain.Repositories;

namespace Project001.ServiceClient.Api.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ClientEntity>> Get([FromServices] IClientRepository repository)
        {
            var datas = await repository.GetApprovedAsync();

            return datas;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ClientEntity> GetById([FromServices] IClientRepository repository, int id)
        {
            var datas = await repository.GetAsync(id);

            return datas;
        }

        [HttpGet]
        [Route("Repproved")]
        public async Task<IEnumerable<ClientEntity>> GetRepproved([FromServices] IClientRepository repository)
        {
            var datas = await repository.GetRepprovedAsync();

            return datas;
        }

        [HttpGet]
        [Route("Pending")]
        public async Task<IEnumerable<ClientEntity>> GetPending([FromServices] IClientRepository repository)
        {
            var datas = await repository.GetPendingAsync();

            return datas;
        }

        [HttpPost]
        [Route("")]
        public async Task<GenericCommandResult<ClientEntity>> Create(
           [FromBody] CreateClientCommand command,
           [FromServices] IClientHandler handler)
        {
            var result = (GenericCommandResult<ClientEntity>)await handler.HandleAsync(command);
            return result;
        }

        [HttpPut]
        [Route("")]
        public async Task<GenericCommandResult<ClientEntity>> Update(
            [FromBody] UpdateClientCommand command,
            [FromServices] IClientHandler handler)
        {
            var result = (GenericCommandResult<ClientEntity>)await handler.HandleAsync(command);

            return result;
        }

        [HttpPut]
        [Route("Approve")]
        public async Task<GenericCommandResult<ClientEntity>> Approve(
                    [FromBody] ApproveClientCommand command,
                    [FromServices] IClientHandler handler)
        {
            var result = (GenericCommandResult<ClientEntity>)await handler.HandleAsync(command);
            return result;
        }

        [HttpPut]
        [Route("Repprove")]
        public async Task<GenericCommandResult<ClientEntity>> Repprove(
            [FromBody] RepproveClientCommand command,
            [FromServices] IClientHandler handler)
        {
            var result = (GenericCommandResult<ClientEntity>)await handler.HandleAsync(command);

            return result;
        }
    }
}