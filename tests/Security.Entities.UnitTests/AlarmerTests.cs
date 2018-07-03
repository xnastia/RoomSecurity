using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;

namespace Security.Entities.UnitTests
{
    [TestFixture]
    public class AlarmerTests
    {
        [Test]
        public void Alarmer_WithNullAlarmMessageHandler_ThrowsArgumentNullException()
        {
            //Act & Assert
            var message = Assert.Throws<ArgumentNullException>(() => new Alarmer(null)).Message;
            Assert.IsTrue(message.Contains("Parameter name: alarmMessageHandler"));
        }

        [Test]
        public void OnIntruder_WithEmptyListOfIntruders_DoesNotInvokeHandleAlarmMessageWithEmptyList()
        {
            //Arrange
            var intruderInTheRoom = new List<string>();
            var intruders = new List<BadgeType>();
            var alarmMessageHandlerMock = MockRepository.GenerateMock<IAlarmMessageHandler>();
            alarmMessageHandlerMock.Expect(x => x.HandleAlarmMessage(intruderInTheRoom)).Repeat.Never();
            var alarmer = new Alarmer(alarmMessageHandlerMock);

            //Act
            alarmer.OnIntruderDetected(intruders);

            //Assert
            alarmMessageHandlerMock.VerifyAllExpectations();
        }

        [Test]
        public void OnIntruder_WithNobadge_InvokeHandleAlarmMessageWithCorrectMessage()
        {
            //Arrange
            var intruderInTheRoom = new List<string>
            {
                "Intruder in the room!"
            };
            var intruders = new List<BadgeType> {BadgeType.NoBadge};
            var alarmMessageHandlerMock = MockRepository.GenerateMock<IAlarmMessageHandler>();
            alarmMessageHandlerMock.Expect(x => x.HandleAlarmMessage(intruderInTheRoom));
            var alarmer = new Alarmer(alarmMessageHandlerMock);

            //Act
            alarmer.OnIntruderDetected(intruders);

            //Assert
            alarmMessageHandlerMock.VerifyAllExpectations();
        }

        [Test]
        public void OnIntruder_WithNullListOfIntruders_ThrowsArgumentNullException()
        {
            //Arrange
            var alarmMessageHandlerMock = MockRepository.GenerateMock<IAlarmMessageHandler>();
            var alarmer = new Alarmer(alarmMessageHandlerMock);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => alarmer.OnIntruderDetected(null));
        }

        [Test]
        public void OnIntruder_WithVisitor_InvokeHandleAlarmMessageWithCorrectMessage()
        {
            //Arrange
            var intruderInTheRoom = new List<string>
            {
                "Visitor not in allowed time."
            };
            var intruders = new List<BadgeType>
            {
                BadgeType.Visitor
            };
            var alarmMessageHandlerMock = MockRepository.GenerateMock<IAlarmMessageHandler>();
            alarmMessageHandlerMock.Expect(x => x.HandleAlarmMessage(intruderInTheRoom));
            var alarmer = new Alarmer(alarmMessageHandlerMock);

            //Act
            alarmer.OnIntruderDetected(intruders);

            //Assert
            alarmMessageHandlerMock.VerifyAllExpectations();
        }

        [Test]
        public void OnIntruder_WithVisitorAndIntruderAndSupport_InvokeHandleAlarmMessageWithCorrectMessage()
        {
            //Arrange
            var intruderInTheRoom = new List<string>
            {
                "Visitor not in allowed time.",
                "Intruder in the room!",
                "Support not in allowed time."
            };
            var intruders = new List<BadgeType>
            {
                BadgeType.Visitor,
                BadgeType.NoBadge,
                BadgeType.Support
            };
            var alarmMessageHandlerMock = MockRepository.GenerateMock<IAlarmMessageHandler>();
            alarmMessageHandlerMock.Expect(x => x.HandleAlarmMessage(intruderInTheRoom));
            var alarmer = new Alarmer(alarmMessageHandlerMock);

            //Act
            alarmer.OnIntruderDetected(intruders);

            //Assert
            alarmMessageHandlerMock.VerifyAllExpectations();
        }

        [Test]
        public void OnIntruder_WithVisitorAndSupport_InvokeHandleAlarmMessageWithCorrectMessage()
        {
            //Arrange
            var intruderInTheRoom = new List<string>
            {
                "Visitor not in allowed time.",
                "Support not in allowed time."
            };
            var intruders = new List<BadgeType>
            {
                BadgeType.Visitor,
                BadgeType.Support
            };
            var alarmMessageHandlerMock = MockRepository.GenerateMock<IAlarmMessageHandler>();
            alarmMessageHandlerMock.Expect(x => x.HandleAlarmMessage(intruderInTheRoom));
            var alarmer = new Alarmer(alarmMessageHandlerMock);

            //Act
            alarmer.OnIntruderDetected(intruders);

            //Assert
            alarmMessageHandlerMock.VerifyAllExpectations();
        }
    }
}