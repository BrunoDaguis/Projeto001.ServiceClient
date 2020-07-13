

using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project001.ServiceClient.Domain.Commands.ClientCommands;

namespace Project001.ServiceClient.Tests.CommandTests.Client
{
    [TestClass]
    public class ApproveClientCommandTests
    {
        private readonly Fixture _fixture = new Fixture();

        private readonly ApproveClientCommand _commandWithoutId;
        private readonly ApproveClientCommand _commandWithId;

        public ApproveClientCommandTests()
        {
            _commandWithoutId = _fixture
                                    .Build<ApproveClientCommand>()
                                    .With(x => x.Id, 0)
                                    .Create();

            _commandWithId = _fixture
                                    .Build<ApproveClientCommand>()
                                    .With(x => x.Id, _fixture.Create<int>())
                                    .Create();
        }

        [TestMethod]
        public void WithoutId()
        {
            _commandWithoutId.Validate();
            Assert.AreEqual(_commandWithoutId.Valid, false);
        }

        [TestMethod]
        public void WithId()
        {
            _commandWithId.Validate();


            Assert.AreEqual(_commandWithId.Valid, true);
        }
    }
}
