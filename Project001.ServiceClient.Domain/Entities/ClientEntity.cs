using Project001.ServiceClient.Domain.Entities.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project001.ServiceClient.Domain.Entities
{
    public class ClientEntity : BaseEntity
    {
        public ClientEntity(string name, DateTime birthDate, ETypeDocument typeDocument, string numberDocument)
        {
            Name = name;
            BirthDate = birthDate;
            TypeDocument = typeDocument;
            NumberDocument = numberDocument;
            Status = EStatusClient.Pending;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public ETypeDocument TypeDocument { get; private set; }
        public string NumberDocument { get; private set; }
        public EStatusClient Status { get; set; }

        public void SetName(string value)
        {
            Name = value;
        }
        public void SetBirthDate(DateTime value)
        {
            BirthDate = value;
        }
        public void SetTypeDocument(ETypeDocument value)
        {
            TypeDocument = value;
        }
        public void SetNumberDocument(string value)
        {
            NumberDocument = value;
        }
        public void SetApproved()
        {
            Status = EStatusClient.Approved;
        }
        public void SetRepproved()
        {
            Status = EStatusClient.Repproved;
        }
    }
}