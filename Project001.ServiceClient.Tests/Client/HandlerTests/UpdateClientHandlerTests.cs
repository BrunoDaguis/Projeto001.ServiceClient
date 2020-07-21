using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Project001.ServiceClient.Domain.Commands;
using Project001.ServiceClient.Domain.Commands.ClientCommands;
using Project001.ServiceClient.Domain.Entities;
using Project001.ServiceClient.Domain.Handlers;
using Project001.ServiceClient.Domain.Handlers.Interfaces;
using Project001.ServiceClient.Domain.Repositories;
using System.Threading.Tasks;

namespace Project001.ServiceClient.Tests.Client.HandlerTests
{
    [TestClass]
    public class UpdateClientHandlerTests
    {
        private readonly Fixture _fixture = new Fixture();
        private readonly IClientRepository _repository;
        private readonly IClientHandler _handler;

        private readonly UpdateClientCommand _commandWithoutName;

        public UpdateClientHandlerTests()
        {
            _repository = Substitute.For<IClientRepository>();
            _handler = new ClientHandler(_repository);

            _commandWithoutName = _fixture
                                    .Build<UpdateClientCommand>()
                                    .Without(x => x.Name)
                                    .Create();
        }

        [TestMethod("[Handler] Update Client - Without Name - Expected: False")]
        public async Task Update_Client_Without_Name()
        {
            var result = (GenericCommandResult<ClientEntity>)await _handler.HandleAsync(_commandWithoutName);
            Assert.AreEqual(result.Success, false);
        }

    }
}
