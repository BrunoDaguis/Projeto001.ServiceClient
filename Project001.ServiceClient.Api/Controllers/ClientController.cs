using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Project001.ServiceClient.Domain.Commands;
using Project001.ServiceClient.Domain.Commands.ClientCommands;
using Project001.ServiceClient.Domain.Entities;
using Project001.ServiceClient.Domain.Entities.Enum;
using Project001.ServiceClient.Domain.Handlers.Interfaces;
using Project001.ServiceClient.Domain.Repositories;

namespace Project001.ServiceClient.Api.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        /// <summary>
        /// Get all actives clients.
        /// </summary>
        /// <returns>Returns all actives clients</returns>
        /// <response code="200">Returns all actives clients</response>
        /// <response code="400">Error</response> 
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin, Client")]
        public async Task<IEnumerable<ClientEntity>> Get([FromServices] IClientRepository repository)
        {
            var datas = await repository.GetApprovedAsync();

            return datas;
        }

        /// <summary>
        /// Get client by id.
        /// </summary>
        /// <returns>Client by id</returns>
        /// <response code="200">Return client by id</response>
        /// <response code="400">Error</response> 
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin, Client")]
        public async Task<ClientEntity> GetById([FromServices] IClientRepository repository, int id)
        {
            var datas = await repository.GetAsync(id);

            return datas;
        }
        /// <summary>
        /// Get all repproveds clients.
        /// </summary>
        /// <returns>All repproveds clients</returns>
        /// <response code="200">Returns all repproveds clients</response>
        /// <response code="400">Error</response> 
        [HttpGet]
        [Route("Repproved")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin, Client")]
        public async Task<IEnumerable<ClientEntity>> GetRepproved([FromServices] IClientRepository repository)
        {
            var datas = await repository.GetRepprovedAsync();

            return datas;
        }
        /// <summary>
        /// Get all pendings clients.
        /// </summary>
        /// <returns>All pendings clients</returns>
        /// <response code="200">Returns all pendings clients</response>
        /// <response code="400">Error</response> 
        [HttpGet]
        [Route("Pending")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin, Client")]
        public async Task<IEnumerable<ClientEntity>> GetPending([FromServices] IClientRepository repository)
        {
            var datas = await repository.GetPendingAsync();

            return datas;
        }

        /// <summary>
        /// Creates a Client.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Client
        ///     {
        ///        "name": "Test name",
        ///        "birthDate": "1990-01-05",
        ///        "typeDocument": 2,
        ///        "numberDocument": "23669966325"
        ///     }
        ///
        /// </remarks>
        /// <param name="command"></param>
        /// <returns>A newly created Client</returns>
        /// <response code="200">Returns the newly created client</response>
        /// <response code="400">If the item is null</response> 
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<GenericCommandResult<ClientEntity>> Create([FromServices] IClientHandler handler,
           [FromBody] CreateClientCommand command)
        {
            var result = (GenericCommandResult<ClientEntity>)await handler.HandleAsync(command);
            return result;
        }
        /// <summary>
        /// Update a Client.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Client
        ///     {
        ///        "id": 1,
        ///        "name": "Test name",
        ///        "birthDate": "1990-01-05",
        ///        "typeDocument": 2,
        ///        "numberDocument": "23669966325"
        ///     }
        ///
        /// </remarks>
        /// <param name="command"></param>
        /// <returns>A updately Client</returns>
        /// <response code="200">Returns the updately client</response>
        /// <response code="400">If the item is null</response> 
        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<GenericCommandResult<ClientEntity>> Update([FromServices] IClientHandler handler,
            [FromBody] UpdateClientCommand command)
        {
            var result = (GenericCommandResult<ClientEntity>)await handler.HandleAsync(command);

            return result;
        }
        /// <summary>
        /// Approve a Client.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Client/Approve
        ///     {
        ///        "id": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="command"></param>
        /// <returns>A approved Client</returns>
        /// <response code="200">Returns the approved client</response>
        /// <response code="400">If the item is null</response> 
        [HttpPut]
        [Route("Approve")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<GenericCommandResult<ClientEntity>> Approve([FromServices] IClientHandler handler,
                    [FromBody] ApproveClientCommand command)
        {
            var result = (GenericCommandResult<ClientEntity>)await handler.HandleAsync(command);
            return result;
        }

        /// <summary>
        /// Repprove a Client.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Client/Repprove
        ///     {
        ///        "id": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="command"></param>
        /// <returns>A repprove Client</returns>
        /// <response code="200">Returns the repprove client</response>
        /// <response code="400">If the item is null</response> 
        [HttpPut]
        [Route("Repprove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<GenericCommandResult<ClientEntity>> Repprove([FromServices] IClientHandler handler,
            [FromBody] RepproveClientCommand command)
        {
            var result = (GenericCommandResult<ClientEntity>)await handler.HandleAsync(command);

            return result;
        }
    }
}