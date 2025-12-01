using AirportDataGridView.Entities.Models;
using AirportDataGridView.Repository.Contracts;
using AirportDataGridView.Services.Contracts;
using FluentAssertions;
using Moq;
using Xunit;

namespace AirportDataGridView.Services.Tests
{
    /// <summary>
    /// Набор тестов для проверки <see cref="PlaneService"/>
    /// </summary>
    public class PlaneServiceTest
    {
        private readonly Mock<IStorage> mockStorage;
        private readonly IService service;
        private readonly CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// Конструктор для класса <see cref="PlaneServiceTest"/>
        /// </summary>
        public PlaneServiceTest()
        {
            mockStorage = new Mock<IStorage>();
            service = new PlaneService(mockStorage.Object);
            cancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// Проверка вызова метода добавления при добавлении в хранилище
        /// </summary>
        [Fact]
        public async Task AddShouldCallStorageAdd()
        {
            var plane = new Plane
            {
                FlightNum = 1,
                PlaneType = PlaneType.Boing,
                Arrive = DateTime.Now.AddDays(2),
                PassengersAmount = 10,
                PassengersFee = 5,
                CrewAmount = 3,
                CrewFee = 10,
                Markup = 15
            };

            await service.Add(plane, cancellationTokenSource.Token);

            mockStorage.Verify(x => x.Add(plane, cancellationTokenSource.Token), Times.Once);
        }

        /// <summary>
        /// Проверка вызова метода удаления при удалении из хранилища
        /// </summary>
        [Fact]
        public async Task DeleteShouldCallStorageDelete()
        {
            var plane = new Plane();
            await service.Add(plane);

            await service.Delete(plane, cancellationTokenSource.Token);

            mockStorage.Verify(x => x.Delete(plane, cancellationTokenSource.Token), Times.Once);
        }

        /// <summary>
        /// Проверка корректности возвращаемых данных при вызове получения всех полетов
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnDataFromStorage()
        {
            var list = new List<Plane>
            {
                new (),
                new (),
            };
            mockStorage
                .Setup(x => x.GetAll(cancellationTokenSource.Token))
                .ReturnsAsync(list);

            var res = await service.GetAll(cancellationTokenSource.Token);

            res.Should().BeSameAs(list);
        }

        /// <summary>
        /// Проверка корректности данных возвращаемой статистики
        /// </summary>
        [Fact]
        public async Task StatisticsShouldReturnCorrectData()
        {
            var expectedStatistics = new PlaneStatistics
            {
                AllFlights = 5,
                AllPassengers = 250,
                AllCrew = 25,
                AllRevenue = 50000
            };

            mockStorage.Setup(s => s.Statistics(cancellationTokenSource.Token))
                       .ReturnsAsync(expectedStatistics);

            var result = await service.Statistics(cancellationTokenSource.Token);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedStatistics);
            mockStorage.Verify(s => s.Statistics(cancellationTokenSource.Token), Times.Once);
        }

        /// <summary>
        /// Проверка обновления полета при вызове метода обновления
        /// </summary>
        [Fact]
        public async Task UpdateShouldUpdateEntityDataInStorage()
        {
            var id = Guid.NewGuid();
            var incomingPlane = new Plane
            {
                Id = id,
                FlightNum = 1,
                PlaneType = PlaneType.Boing,
                Arrive = DateTime.Now.AddDays(2),
                PassengersAmount = 10,
                PassengersFee = 5,
                CrewAmount = 3,
                CrewFee = 10,
                Markup = 15
            };

            mockStorage.Setup(x => x.Update(
                It.Is<Plane>(p =>
                    p.FlightNum == 1 &&
                    p.PlaneType == PlaneType.Boing &&
                    p.PassengersAmount == 10 &&
                    p.PassengersFee == 5 &&
                    p.CrewAmount == 3 &&
                    p.CrewFee == 10 &&
                    p.Markup == 15
                ), cancellationTokenSource.Token)
            ).Returns(Task.CompletedTask);

            await service.Update(incomingPlane, cancellationTokenSource.Token);

            mockStorage.Verify(s => s.Update(
                It.Is<Plane>(p =>
                    p.FlightNum == incomingPlane.FlightNum &&
                    p.PlaneType == incomingPlane.PlaneType &&
                    p.Arrive == incomingPlane.Arrive &&
                    p.PassengersAmount == incomingPlane.PassengersAmount &&
                    p.PassengersFee == incomingPlane.PassengersFee &&
                    p.CrewAmount == incomingPlane.CrewAmount &&
                    p.CrewFee == incomingPlane.CrewFee &&
                    p.Markup == incomingPlane.Markup
                ), cancellationTokenSource.Token), Times.Once
            );
        }
    }
}
