using Flunt.Notifications;
using Flunt.Validations;
using Project001.ServiceClient.Domain.Commands.Interfaces;

namespace Project001.ServiceClient.Domain.Commands.ClientCommands
{
    public class RepproveClientCommand : Notifiable, ICommand
    {
        public RepproveClientCommand()
        {

        }
        public RepproveClientCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public void Validate()
        {
            AddNotifications(
              new Contract()
              .Requires()
              .AreNotEquals(Id, 0, "Id", "Nenhum cliente para Reprovação")
            );
        }
    }
}
