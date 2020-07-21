using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project001.ServiceClient.Domain.Commands.ClientCommands;
using Project001.ServiceClient.Domain.Entities.Enum;
using System;

namespace Project001.ServiceClient.Tests.Client.CommandTests
{
    [TestClass]
    public class UpdateClientCommandTests
    {
        private readonly Fixture _fixture = new Fixture();

        private readonly UpdateClientCommand _commandWithoutId;
        private readonly UpdateClientCommand _commandWithId;

        private readonly UpdateClientCommand _commandWithoutName;
        private readonly UpdateClientCommand _commandValidName;

        private readonly UpdateClientCommand _commandWithoutBirthDate;
        private readonly UpdateClientCommand _commandBirthDateGreaterCurrent;
        private readonly UpdateClientCommand _commandValidBirthDate;

        private readonly UpdateClientCommand _commandWithouTypeDocument;
        private readonly UpdateClientCommand _commandInvalidTypeDocument;
        private readonly UpdateClientCommand _commandValidTypeDocument;

        private readonly UpdateClientCommand _commandWithoutNumberDocument;
        private readonly UpdateClientCommand _commandValidNumberDocument;

        public UpdateClientCommandTests()
        {
            _commandWithoutId = _fixture
                                    .Build<UpdateClientCommand>()
                                    .Without(x => x.Id)
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandWithId = _fixture
                                    .Build<UpdateClientCommand>()
                                    .With(x => x.Id, _fixture.Create<int>())
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandWithoutName = _fixture
                                    .Build<UpdateClientCommand>()
                                    .Without(x => x.Name)
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandValidName = _fixture
                                    .Build<UpdateClientCommand>()
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandWithoutBirthDate = _fixture
                                    .Build<UpdateClientCommand>()
                                    .Without(x => x.BirthDate)
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandBirthDateGreaterCurrent = _fixture
                                    .Build<UpdateClientCommand>()
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(1))
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandValidBirthDate = _fixture
                                    .Build<UpdateClientCommand>()
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandWithouTypeDocument = _fixture
                                    .Build<UpdateClientCommand>()
                                    .Without(x => x.TypeDocument)
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandInvalidTypeDocument = _fixture
                                    .Build<UpdateClientCommand>()
                                    .With(x => (int)x.TypeDocument, 999)
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandValidTypeDocument = _fixture
                                    .Build<UpdateClientCommand>()
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .Create();

            _commandWithoutNumberDocument = _fixture
                                    .Build<UpdateClientCommand>()
                                    .Without(x => x.NumberDocument)
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .Create();

            _commandValidNumberDocument = _fixture
                                    .Build<UpdateClientCommand>()
                                    .With(x => x.NumberDocument, _fixture.Create<string>())
                                    .With(x => x.TypeDocument, ETypeDocument.Cnh)
                                    .With(x => x.BirthDate, DateTime.Now.AddDays(-100))
                                    .With(x => x.Name, _fixture.Create<string>())
                                    .Create();

        }

        [TestMethod("[Command] Update Client - Without Id - Expected: False")]
        public void WithoutId()
        {
            _commandWithoutId.Validate();
            Assert.AreEqual(_commandWithoutId.Valid, false);
        }

        [TestMethod("[Command] Update Client - Id Valid - Expected: True")]
        public void WithId()
        {
            _commandWithId.Validate();
            Assert.AreEqual(_commandWithId.Valid, true);
        }

        [TestMethod("[Command] Update Client - Without Name - Expected: False")]
        public void WithoutName()
        {
            _commandWithoutName.Validate();
            Assert.AreEqual(_commandWithoutName.Valid, false);
        }
        [TestMethod("[Command] Update Client - Name Valid - Expected: True")]
        public void ValidName()
        {
            _commandValidName.Validate();
            Assert.AreEqual(_commandValidName.Valid, true);
        }
        [TestMethod("[Command] Update Client - Without birthDate - Expected: False")]
        public void WithoutBirthDate()
        {
            _commandWithoutBirthDate.Validate();
            Assert.AreEqual(_commandWithoutBirthDate.Valid, false);
        }
        [TestMethod("[Command] Update Client - BirthDate Invalid - Expected: False")]
        public void BirthDateGreaterCurrent()
        {
            _commandBirthDateGreaterCurrent.Validate();
            Assert.AreEqual(_commandBirthDateGreaterCurrent.Valid, false);
        }

        [TestMethod("[Command] Update Client - BirtDate Valid - Expected: True")]
        public void ValidBirthDate()
        {
            _commandValidBirthDate.Validate();
            Assert.AreEqual(_commandValidBirthDate.Valid, true);
        }
        [TestMethod("[Command] Update Client - Without Type Document - Expected: False")]
        public void WithouTypeDocument()
        {
            _commandWithouTypeDocument.Validate();
            Assert.AreEqual(_commandWithouTypeDocument.Valid, false);
        }
        [TestMethod("[Command] Update Client - Type Document Invalid - Expected: False")]
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
        [TestMethod("[Command] Update Client - Type Document Valid - Expected: True")]
        public void ValidTypeDocument()
        {
            _commandValidTypeDocument.Validate();
            Assert.AreEqual(_commandValidTypeDocument.Valid, true);
        }
        [TestMethod("[Command] Update Client - Without Number Document - Expected: False")]
        public void WithoutNumberDocument()
        {
            _commandWithoutNumberDocument.Validate();
            Assert.AreEqual(_commandWithoutNumberDocument.Valid, false);
        }
        [TestMethod("[Command] Update Client - Number Documento Valid - Expected: True")]
        public void ValidNumberDocument()
        {
            _commandValidNumberDocument.Validate();
            Assert.AreEqual(_commandValidNumberDocument.Valid, true);
        }
    }
}
