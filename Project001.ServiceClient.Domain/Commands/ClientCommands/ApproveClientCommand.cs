using Flunt.Notifications;
using Flunt.Validations;
using Project001.ServiceClient.Domain.Commands.Interfaces;

namespace Project001.ServiceClient.Domain.Commands.ClientCommands
{
    public class ApproveClientCommand : Notifiable, ICommand
    {
        public ApproveClientCommand()
        {
                
        }
        public ApproveClientCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public void Validate()
        {
            AddNotifications(
              new Contract()
              .Requires()
              .AreNotEquals(Id, 0, "Id", "Nenhum cliente para Aprovação")
            );
        }
    }
}
