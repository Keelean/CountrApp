using Countr.Core.Models;
using Countr.Core.Repositories;
using Countr.Core.Service;
using Moq;
using MvvmCross.Plugins.Messenger;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countr.Core.Tests.Services
{
    [TestFixture]
    public class CountersServiceTests
    {
        ICountersService service;
        readonly IMvxMessenger messenger;
        Mock<ICounterRepository> repo;

        [SetUp]
        public void SetUp()
        {
            repo = new Mock<ICounterRepository>();
            service = new CountersService(repo.Object,messenger);
        }

        [Test]
        public async Task IncrementCounter_IncrementsTheCounter()
        {
            // Arrange
            var counter = new Counter { Count = 0 };
            // Act
            await service.IncrementCounter(counter);
            // Assert
            Assert.AreEqual(1, counter.Count);
        }

        [Test]
        public async Task IncrementCounter_SavesTheIncrementedCounter()
        {
            // Arrange
            var counter = new Counter { Count = 0 };
            // Act
            await service.IncrementCounter(counter);
            // Assert
            repo.Verify(r => r.Save(It.Is<Counter>(c => c.Count == 1)),
            Times.Once());
        }
    }
}
