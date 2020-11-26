using ArchTest.Core.Extensions.CqrsLite;
using ArchTest.Domain.Commands.Inkoop;
using CQRSlite.Commands;
using FluentAssertions;
using Moq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit;

namespace ArchTest.Domain.Tests
{
    public class InkoopOrderCommandValidationTests
    {
        private const string EmptyGuid = "00000000-0000-0000-0000-000000000000";
        private const string ValidGuid = "986a4bc0-20b7-4c81-b145-e217674e5852";

        [Theory]
        [InlineData(EmptyGuid, ValidGuid, ValidGuid)]
        [InlineData(ValidGuid, EmptyGuid, ValidGuid)]
        [InlineData(ValidGuid, ValidGuid, EmptyGuid)]
        public void CreateInkoopOrderThrowsValidationException(Guid opdrachtgeverId, Guid bevrachterId, Guid ladingId)
        {
            // Arrange
            var command = new CreateInkoopOrder(opdrachtgeverId, bevrachterId, ladingId, null);
            var commandSender = new Mock<ICommandSender>().Object;

            // Act
            Func<Task> act = async () => await commandSender.ValidateAndSend(command);

            act.Should().Throw<ValidationException>();
        }

        [Fact]
        public async Task CreateInkoopOrderSucceeds()
        {
            // Arrange
            var command = new CreateInkoopOrder(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), null);
            var commandSender = new Mock<ICommandSender>().Object;

            // Act
            await commandSender.ValidateAndSend(command);
        }
    }
}
