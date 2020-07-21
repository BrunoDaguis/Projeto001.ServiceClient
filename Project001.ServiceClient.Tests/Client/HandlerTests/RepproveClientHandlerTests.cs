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
    public class RepproveClientHandlerTests
    {
        private readonly Fixture _fixture = new Fixture();
        private readonly IClientRepository _repository;
        private readonly IClientHandler _handler;

        private readonly RepproveClientCommand _commandWithoutId;

        public RepproveClientHandlerTests()
        {
            _repository = Substitute.For<IClientRepository>();
            _handler = new ClientHandler(_repository);

            _commandWithoutId = _fixture
                                    .Build<RepproveClientCommand>()
                                    .Without(x => x.Id)
                                    .Create();
        }

        [TestMethod("[Handler] Client Repprove - Without Id - Expected: False")]
        public async Task Repprove_Client_Without_Id()
        {
            var result = (GenericCommandResult<ClientEntity>)await _handler.HandleAsync(_commandWithoutId);
            Assert.AreEqual(result.Success, false);
        }
    }
}
