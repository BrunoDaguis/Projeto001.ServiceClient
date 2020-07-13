using Flunt.Notifications;
using Project001.ServiceClient.Domain.Commands;
using Project001.ServiceClient.Domain.Commands.ClientCommands;
using Project001.ServiceClient.Domain.Commands.Interfaces;
using Project001.ServiceClient.Domain.Entities;
using Project001.ServiceClient.Domain.Handlers.Interfaces;
using Project001.ServiceClient.Domain.Repositories;
using System.Threading.Tasks;

namespace Project001.ServiceClient.Domain.Handlers
{
    public class ClientHandler : Notifiable, IClientHandler
    {
        private readonly IClientRepository _repository;

        public ClientHandler(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> HandleAsync(CreateClientCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult<ClientEntity>(false, command.Notifications);

            var client = new ClientEntity(command.Name, command.BirthDate, command.TypeDocument, command.NumberDocument);

            await _repository.CreateAsync(client);
            return new GenericCommandResult<ClientEntity>(true, client);
        }

        public async Task<ICommandResult> HandleAsync(UpdateClientCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult<ClientEntity>(false, command.Notifications);

            var client = await _repository.GetAsync(command.Id);

            client.SetName(command.Name);
            client.SetBirthDate(command.BirthDate);
            client.SetTypeDocument(command.TypeDocument);
            client.SetNumberDocument(command.NumberDocument);

            await _repository.UpdateAsync(client);

            return new GenericCommandResult<ClientEntity>(true, client);
        }

        public async Task<ICommandResult> HandleAsync(ApproveClientCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult<ClientEntity>(false, command.Notifications);

            var client = await _repository.GetAsync(command.Id);

            client.SetApproved();
            await _repository.UpdateAsync(client);

            return new GenericCommandResult<ClientEntity>(true, client);
        }

        public async Task<ICommandResult> HandleAsync(RepproveClientCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult<ClientEntity>(false, command.Notifications);

            var client = await _repository.GetAsync(command.Id);

            client.SetRepproved();
            await _repository.UpdateAsync(client);

            return new GenericCommandResult<ClientEntity>(true, client);
        }
    }
}
