using Flunt.Notifications;
using Flunt.Validations;
using Project001.ServiceClient.Domain.Commands.Interfaces;
using Project001.ServiceClient.Domain.Entities.Enum;
using System;

namespace Project001.ServiceClient.Domain.Commands.ClientCommands
{
    public class CreateClientCommand : Notifiable, ICommand
    {
        public CreateClientCommand()
        {

        }

        public CreateClientCommand(string name, DateTime birthDate, ETypeDocument typeDocument, string numberDocument)
        {
            Name = name;
            BirthDate = birthDate;
            TypeDocument = typeDocument;
            NumberDocument = numberDocument;
        }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ETypeDocument TypeDocument { get; set; }
        public string NumberDocument { get; set; }

        public void Validate()
        {
            AddNotifications(
              new Contract()
              .Requires()
              .HasMinLen(Name, 3, "name", "Nome deve ter minimo de 3 caracteres")
              .HasMaxLen(Name, 100, "name", "Nome deve ter máximo de 100 caracteres")
              .IsGreaterThan(BirthDate, DateTime.MinValue, "BirthDate", "Data de aniversario inválida")
              .IsLowerThan(BirthDate, DateTime.Now, "BirthDate", "Data de aniversário deve ser menor que data atual")
              .IsGreaterThan((int)TypeDocument, 0, "TypeDocument", "Tipo de Documento Inválido")
              .IsLowerThan((int)TypeDocument, 4, "TypeDocument", "Tipo de Documento Inválido")
              .IsNotNullOrWhiteSpace(NumberDocument, "NumberDocument", "Número do documento inválido")
            );
        }
    }
}
