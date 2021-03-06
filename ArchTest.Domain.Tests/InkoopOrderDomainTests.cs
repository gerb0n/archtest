using ArchTest.Domain.Tests.Builders;
using ArchTest.Domain.WriteModel.Entities;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace ArchTest.Domain.Tests
{
    public class InkoopOrderDomainTests
    {
        [Fact]
        public void CreateOnInkoopOrderSucceeds()
        {
            Guid opdrachtgeverId = Guid.NewGuid();
            Guid bevrachterId = Guid.NewGuid();
            Guid ladingId = Guid.NewGuid();
            int hoeveelheid = 10;

            // Arrange
            var inkoopOrder = new InkoopOrder();

            // Act
            inkoopOrder.Create(opdrachtgeverId, bevrachterId, ladingId, hoeveelheid);

            inkoopOrder.OpdrachtgeverId.Should().Be(opdrachtgeverId);
            inkoopOrder.BevrachterId.Should().Be(bevrachterId);
            inkoopOrder.LadingId.Should().Be(ladingId);
            inkoopOrder.Hoeveelheid.Should().Be(hoeveelheid);
        }

        [Fact]
        public void AddLaadPlaatsOnInkoopOrderSucceeds()
        {
            // Arrange
            var builder = new InkoopOrderBuilder();
            Guid inkoopOrderPlaatsId = Guid.NewGuid();
            Guid plaatsId = Guid.NewGuid();
            Guid vestigingId = Guid.NewGuid();
            Guid overslagbedrijfId = Guid.NewGuid();

            var inkoopOrder = builder
                .Default()
                .Build();

            // Act
            inkoopOrder.AddLaadPlaats(inkoopOrderPlaatsId, plaatsId, vestigingId, overslagbedrijfId);

            inkoopOrder.LaadPlaatsen.Should().NotBeEmpty();
            inkoopOrder.LaadPlaatsen.Count.Should().Be(1);

            var laadplaats = inkoopOrder.LaadPlaatsen[0];
            laadplaats.Id.Should().Be(inkoopOrderPlaatsId);
            laadplaats.PlaatsId.Should().Be(plaatsId);
            laadplaats.VestigingId.Should().Be(vestigingId);
            laadplaats.OverslagbedrijfId.Should().Be(overslagbedrijfId);
        }

        [Fact]
        public void AddLaadPlaatsOnInkoopOrderAlreadyExistsThrowsException()
        {
            // Arrange
            var builder = new InkoopOrderBuilder();
            Guid inkoopOrderPlaatsId = Guid.NewGuid();
            Guid plaatsId = Guid.NewGuid();
            Guid vestigingId = Guid.NewGuid();
            Guid overslagbedrijfId = Guid.NewGuid();

            var inkoopOrder = builder
                .Default()
                .WithPlaats(inkoopOrderPlaatsId, plaatsId, vestigingId, overslagbedrijfId)
                .Build();

            // Act
            Action act = () => inkoopOrder.AddLaadPlaats(inkoopOrderPlaatsId, plaatsId, vestigingId, overslagbedrijfId);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void AddVerlaadBeurtAanvraagOnInkoopOrderSucceeds()
        {
            // Arrange
            var builder = new InkoopOrderBuilder();
            Guid schipId = Guid.NewGuid();
            DateTime datum = new DateTime(2020, 1, 1);
            string bijzonderheden = "bijzonderheden";

            var inkoopOrder = builder
                .Default()
                .WithPlaats()
                .Build();

            var plaats = inkoopOrder.LaadPlaatsen.First();

            // Act
            plaats.VerlaadBeurtAanvragen(schipId, datum, bijzonderheden);

            // Assert
            var laadplaats = inkoopOrder.LaadPlaatsen[0];
            laadplaats.VerlaadBeurt.SchipId.Should().Be(schipId);
            laadplaats.VerlaadBeurt.Datum.Should().Be(datum);
            laadplaats.VerlaadBeurt.Bijzonderheden.Should().Be(bijzonderheden);
        }
    }
}
