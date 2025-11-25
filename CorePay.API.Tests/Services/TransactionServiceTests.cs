using CorePayAPI.Repository.Interface;
using Moq;
using CorePay.API.Application.Services;
using CorePay.API.Domain.Entities;
using CorePayAPI.DTOs.Requests;
using FluentAssertions;

namespace CorePay.API.UnitTests.Services
{
    public class TransactionServiceTests
    {
        private readonly Mock<ITransferRepository> _repoMock;
        private readonly TransactionService _service;

        public TransactionServiceTests()
        {
            _repoMock = new Mock<ITransferRepository>();
            _service = new TransactionService(_repoMock.Object);
        }

        [Fact]
        public async Task TrasnferMoneyAsync_ShouldReturnError_WhenUserNotFound()
        {
            //Arrange
            _repoMock.Setup(r => r.GetUserByIdAsync(1)).ReturnsAsync((User)null);

            var request = new TransferRequest { SenderId = 1, ReceiverId = 2, Amount = 50 };

            // Act
            var result = await _service.TransferMoneyAsync(request);

            // Assert
            result.Success.Should().BeFalse();
            result.ErrorMessage.Should().Be("Transaction failed: user not found.");
        }
        [Fact]
        public async Task TransferMoneyAsync_ShouldReturnError_WhenValueNegative()
        {
            //Arrange
             _repoMock.Setup(r => r.GetUserByIdAsync(1)).ReturnsAsync(new User { Id = 1, Balance = 100 });

            _repoMock.Setup(r => r.GetUserByIdAsync(2)).ReturnsAsync(new User { Id = 2, Balance = 100 });

            var request = new TransferRequest { SenderId = 1, ReceiverId = 2, Amount = -1 };

            //Act
            var result = await _service.TransferMoneyAsync(request);

            //Assert
            result.Success.Should().BeFalse();
            result.ErrorMessage.Should().Be("Transaction failed: Invalid transfer value.");
        }
    }
}
