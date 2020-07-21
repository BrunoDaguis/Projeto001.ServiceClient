using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project001.ServiceClient.Domain.Commands.ClientCommands;
using System.Diagnostics;

namespace Project001.ServiceClient.Tests.Client.CommandTests
{
    [TestClass]
    public class RepproveClientCommandTests
    {
        private readonly Fixture _fixture = new Fixture();

        private readonly RepproveClientCommand _commandWithoutId;
        private readonly RepproveClientCommand _commandWithId;

        public RepproveClientCommandTests()
        {
            _commandWithoutId = _fixture
                                    .Build<RepproveClientCommand>()
                                    .With(x => x.Id, 0)
                                    .Create();

            _commandWithId = _fixture
                                    .Build<RepproveClientCommand>()
                                    .With(x => x.Id, _fixture.Create<int>())
                                    .Create();
        }

        [TestMethod("[Command] Repprove Client - Without Id - Expected: False")]
        public void WithoutId()
        {
            _commandWithoutId.Validate();
            Assert.AreEqual(_commandWithoutId.Valid, false);
        }

        [TestMethod("[Command] Repprove Client - Id Valid - Expected: True")]
        public void WithId()
        {
            _commandWithId.Validate();
            

            Assert.AreEqual(_commandWithId.Valid, true);
        }
    }
}
