using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project001.ServiceClient.Domain.Commands.ClientCommands;
using Project001.ServiceClient.Domain.Entities.Enum;
using System;
using System.Diagnostics;

namespace Project001.ServiceClient.Tests.CommandTests.Client
{
    [TestClass]
    public class CreateClientCommandTests
    {
        private readonly Fixture _fixture = new Fixture();

        private readonly CreateClientCommand _commandWithoutName;
        private readonly CreateClientCommand _commandValidName;

        private readonly CreateClientCommand _commandWithoutBirthDate;
        private readonly CreateClientCommand _commandBirthDateGreaterCurrent;
        private readonly CreateClientCommand _commandValidBirthDate;

        private readonly CreateClientCommand _commandWithouTypeDocument;
        private readonly CreateClientCommand _commandInvalidTypeDocument;
        private readonly CreateClientCommand _commandValidTypeDocument;

        private readonly CreateClientCommand _commandWithoutNumberDocument;
        private readonly CreateClientCommand _commandValidNumberDocument;

        public CreateClientCommandTests()
        {
            _commandWithoutName = _fixture
                                    .Build<CreateClientCommand>()
                                    .Without(x => x.Name)
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandValidName = _fixture
                                    .Build<CreateClientCommand>()
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandWithoutBirthDate = _fixture
                                    .Build<CreateClientCommand>()
                                    .Without(x => x.BirthDate)
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandBirthDateGreaterCurrent = _fixture
                                    .Build<CreateClientCommand>()
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(1))
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandValidBirthDate = _fixture
                                    .Build<CreateClientCommand>()
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandWithouTypeDocument = _fixture
                                    .Build<CreateClientCommand>()
                                    .Without(x => x.TypeDocument)
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandInvalidTypeDocument = _fixture
                                    .Build<CreateClientCommand>()
                                    .With(x => (int)x.TypeDocument, 999)
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandValidTypeDocument = _fixture
                                    .Build<CreateClientCommand>()
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandWithoutNumberDocument = _fixture
                                    .Build<CreateClientCommand>()
                                    .Without(x => x.NumberDocument)
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .Create();

            _commandValidNumberDocument = _fixture
                                    .Build<CreateClientCommand>()
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .Create();

        }

        [TestMethod]
        public void WithoutName()
        {
            _commandWithoutName.Validate();
            Assert.AreEqual(_commandWithoutName.Valid, false);
        }
        [TestMethod]
        public void ValidName()
        {
            _commandValidName.Validate();
            Assert.AreEqual(_commandValidName.Valid, true);
        }
        [TestMethod]
        public void WithoutBirthDate()
        {
            _commandWithoutBirthDate.Validate();
            Assert.AreEqual(_commandWithoutBirthDate.Valid, false);
        }
        [TestMethod]
        public void BirthDateGreaterCurrent()
        {
            _commandBirthDateGreaterCurrent.Validate();
            Assert.AreEqual(_commandBirthDateGreaterCurrent.Valid, false);
        }

        [TestMethod]
        public void ValidBirthDate()
        {
            _commandValidBirthDate.Validate();
            Assert.AreEqual(_commandValidBirthDate.Valid, true);
        }
        [TestMethod]
        public void WithouTypeDocument()
        {
            _commandWithouTypeDocument.Validate();
            Assert.AreEqual(_commandWithouTypeDocument.Valid, false);
        }
        [TestMethod]
        public void InvalidTypeDocument()
        {
            _commandInvalidTypeDocument.Validate();
            /*Trace.WriteLine((int)_commandInvalidTypeDocument.TypeDocument);

            foreach (var item in _commandInvalidTypeDocument.Notifications)
            {
                Trace.WriteLine(item.Message);
            }*/
            Assert.AreEqual(_commandInvalidTypeDocument.Valid, false);
        }
        [TestMethod]
        public void ValidTypeDocument()
        {
            _commandValidTypeDocument.Validate();
            Assert.AreEqual(_commandValidTypeDocument.Valid, true);
        }
        [TestMethod]
        public void WithoutNumberDocument()
        {
            _commandWithoutNumberDocument.Validate();
            Assert.AreEqual(_commandWithoutNumberDocument.Valid, false);
        }
        [TestMethod]
        public void ValidNumberDocument()
        {
            _commandValidNumberDocument.Validate();
            Assert.AreEqual(_commandValidNumberDocument.Valid, true);
        }
    }
}
