// ****************************************************************
//  Assembly         : CleanArchitecture.Api.UnitTests
//  Author           :  cmalagoncmalagon
//  Created          : 01-11-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-11-2025
//  ****************************************************************
//  <copyright file="OwnersControllerTest.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Millon.TecnicalTest.RealEstate.Api.Controllers.Owners;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Owners;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Owner;
using Millon.TecnicalTest.RealEstate.Application.Common.Options;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Owners;
using Moq;

namespace Millon.TecnicalTest.RealEstate.Api.UnitTests.Controllers.Owner
{
    public class OwnersControllerTest
    {
        private readonly Mock<IOwnerServices> _ownerserviceMock;
        private readonly Mock<IOptions<ApplicationOptions>> _applicationOptionsMock;

        public OwnersControllerTest()
        {
            _ownerserviceMock = new Mock<IOwnerServices>(MockBehavior.Strict);
            _applicationOptionsMock = new Mock<IOptions<ApplicationOptions>>(MockBehavior.Strict);
        }

        /// <summary>
        /// <MethodName>_should_<expectation>_when_<condition>
        /// nameOfMethodBeingTested_Scenario_ExpectedBehaviour
        /// </summary>
        [Fact]
        public async Task GetOwnerShouldGettheownerWhenIdexistAsync()
        {
            // Arrange
            _ownerserviceMock.Setup(x => x.SelectOwnerByIdAsync(1, default))
                .ReturnsAsync(new OwnerResponse
                {
                    Id = 1,
                    Name = "Carlos Malagón",
                    Address = "Calle 66C",
                    Photo ="cafemaca.png",
                    Birthday = new DateOnly(1970, 6,26)
                }
                );

            // Act
            var controller = new OwnersController(_ownerserviceMock.Object, _applicationOptionsMock.Object);
            var result = await controller.GetOwner(1);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var item = Assert.IsType<OwnerResponse>(okResult.Value);
            Assert.Equal(1, item.Id);

        }

        [Fact]
        public async Task GetOwnerShouldGetErrorWhenIdNonexistAsync()
        {
            // Arrange
            _ownerserviceMock.Setup(x => x.SelectOwnerByIdAsync(0, default))
                .ReturnsAsync(OwnerErrors.NotFound(0)
                );

            // Act
            var controller = new OwnersController(_ownerserviceMock.Object, _applicationOptionsMock.Object);
            var result = await controller.GetOwner(0);

            //Assert
            var errorResult = Assert.IsType<NotFoundObjectResult>(result);
            var item = Assert.IsType<DomainError>(errorResult.Value);
            Assert.Equal(OwnerErrors.NotFound(0).ErrorCode, item.ErrorCode);

        }
    }
}
