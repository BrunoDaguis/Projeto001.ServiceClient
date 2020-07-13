using Flunt.Notifications;
using Project001.ServiceClient.Domain.Commands.Interfaces;
using Project001.ServiceClient.Domain.Entities;
using System.Collections.Generic;

namespace Project001.ServiceClient.Domain.Commands
{
    public class GenericCommandResult<T> : ICommandResult where T : BaseEntity
    {
        public GenericCommandResult()
        {
        }

        public GenericCommandResult(bool success, T data)
        {
            Success = success;
            Data = data;
        }

        public GenericCommandResult(bool success, IReadOnlyCollection<Notification> notifications)
        {
            Success = success;
            Notifications = notifications;
        }

        public bool Success { get; set; }
        public T Data { get; set; }
        public IReadOnlyCollection<Notification> Notifications { get; set; }
    }
}
