using Project001.ServiceClient.Domain.Commands.ClientCommands;

namespace Project001.ServiceClient.Domain.Handlers.Interfaces
{
    public interface IClientHandler :
    IHandler<CreateClientCommand>,
    IHandler<UpdateClientCommand>,
    IHandler<ApproveClientCommand>,
    IHandler<RepproveClientCommand>
    {
    }
}
