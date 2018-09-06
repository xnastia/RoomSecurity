using System;
using System.Collections.Generic;
using NUnit.Framework;
using Security.BusinessLogic;
using Rhino.Mocks;
using Security.Entities;

namespace RoomSecurity.UnitTests
{
    [TestFixture]
    class MonitorTests
    {
        class InvokeMethodHandlerHelper
        {
            public InvokeMethodHandlerHelper()
            {
                MethodWasCalled = false;
            }

            public bool MethodWasCalled { get; set; }

            public void MethodHandler(CheckerResponse checkerResponse)
            {
                MethodWasCalled = true;
            }
        }

        ISecurityScanner securityScannerMock = MockRepository.GenerateMock<ISecurityScanner>();
        DateTime currentTime = DateTime.Now;

        [Test]
        public void Scan_OnEventOnIntruder_InvokesEventOnIntruderDetectedHandler()
        {
            //Arrange
            InvokeMethodHandlerHelper invokeMethodHandlerHelper = new InvokeMethodHandlerHelper();
            securityScannerMock.Stub(x => x.CheckRoom(currentTime))
                .Return(new CheckerResponse(1, 
                new List<BadgeType>
                {
                    BadgeType.NoBadge
                }, 
                currentTime));
            List<ISecurityScanner> scanners = new List<ISecurityScanner>
            {
                securityScannerMock
            };
            Monitor monitor = new Monitor(scanners);
            monitor.EventOnIntruderDetected += invokeMethodHandlerHelper.MethodHandler;

            //Act
            monitor.Scan(currentTime);

            //Assert
            Assert.IsTrue(invokeMethodHandlerHelper.MethodWasCalled);
        }

        [Test]
        public void Scan_OnEventOnIntruder_NotInvokesOnNoIntruderFound()
        {
            //Arrange
            InvokeMethodHandlerHelper invokeMethodHandlerHelper = new InvokeMethodHandlerHelper();
            securityScannerMock.Stub(x => x.CheckRoom(currentTime))
                .Return(new CheckerResponse(1, new List<BadgeType>(), currentTime));
            List<ISecurityScanner> scanners = new List<ISecurityScanner>
            {
                securityScannerMock
            };
            Monitor monitor = new Monitor(scanners);
            monitor.EventOnIntruderDetected += invokeMethodHandlerHelper.MethodHandler;

            //Act
            monitor.Scan(currentTime);

            //Assert
            Assert.IsFalse(invokeMethodHandlerHelper.MethodWasCalled);
        }

        [Test]
        public void Scan_OnEventOnCheckDone_Invokes()
        {
            //Arrange
            InvokeMethodHandlerHelper invokeMethodHandlerHelper = new InvokeMethodHandlerHelper();
            securityScannerMock.Stub(x => x.CheckRoom(currentTime))
                .Return(new CheckerResponse(1, new List<BadgeType>(), currentTime));
            List<ISecurityScanner> scanners = new List<ISecurityScanner>
            {
                securityScannerMock
            };
            Monitor monitor = new Monitor(scanners);
            monitor.EventOnCheckDone += invokeMethodHandlerHelper.MethodHandler;

            //Act
            monitor.Scan(currentTime);

            //Assert
            Assert.IsTrue(invokeMethodHandlerHelper.MethodWasCalled);
        }
    }
}
