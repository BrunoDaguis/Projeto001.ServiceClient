using Project001.ServiceClient.Domain.Commands.Interfaces;
using System.Threading.Tasks;

namespace Project001.ServiceClient.Domain.Handlers.Interfaces
{
    public interface IHandler<TCommand> where TCommand : ICommand
    {
        Task<ICommandResult> HandleAsync(TCommand command);
    }
}
