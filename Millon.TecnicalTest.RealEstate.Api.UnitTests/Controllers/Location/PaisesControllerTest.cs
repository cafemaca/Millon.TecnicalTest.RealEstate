// ****************************************************************
//  Assembly         : CleanArchitecture.Api.UnitTests
//  Author           :  cmalagoncmalagon
//  Created          : 06-15-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 06-15-2024
//  ****************************************************************
//  <copyright file="PaisesControllerTest.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Millon.TecnicalTest.RealEstate.Api.Controllers.Location;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Location;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Location;
using Millon.TecnicalTest.RealEstate.Application.Common.Options;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Locations;
using Moq;

namespace Millon.TecnicalTest.RealEstate.Api.UnitTests.Controllers.Paises
{
    public class PaisesControllerTest
    {
        private readonly Mock<IPaisServices> _playerserviceMock;
        private readonly Mock<IOptions<ApplicationOptions>> _applicationOptionsMock;

        public PaisesControllerTest()
        {
            _playerserviceMock = new Mock<IPaisServices>(MockBehavior.Strict);
            _applicationOptionsMock = new Mock<IOptions<ApplicationOptions>>(MockBehavior.Strict);
        }

        /// <summary>
        /// <MethodName>_should_<expectation>_when_<condition>
        /// nameOfMethodBeingTested_Scenario_ExpectedBehaviour
        /// </summary>
        [Fact]
        public async Task GetPaisShouldGettheplayerWhenIdexistAsync()
        {
            // Arrange
            _playerserviceMock.Setup(x => x.SelectPaisByIdAsync("PA", default))
                .ReturnsAsync(new PaisResponse
                {
                    Id = "PA",
                    Name = "País"
                }
                );

            // Act
            var controller = new PaisesController(_playerserviceMock.Object, _applicationOptionsMock.Object);
            var result = await controller.GetPais("PA");

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var item = Assert.IsType<PaisResponse>(okResult.Value);
            Assert.Equal("PA", item.Id);

        }

        [Fact]
        public async Task GetPaisShouldGetErrorWhenIdNonexistAsync()
        {
            // Arrange
            _playerserviceMock.Setup(x => x.SelectPaisByIdAsync("0", default))
                .ReturnsAsync(PaisErrors.NotFound("0")
                );

            // Act
            var controller = new PaisesController(_playerserviceMock.Object, _applicationOptionsMock.Object);
            var result = await controller.GetPais("0");

            //Assert
            var errorResult = Assert.IsType<NotFoundObjectResult>(result);
            var item = Assert.IsType<DomainError>(errorResult.Value);
            Assert.Equal(PaisErrors.NotFound("0").ErrorCode, item.ErrorCode);

        }
    }
}
