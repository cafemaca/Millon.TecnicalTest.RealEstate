// ****************************************************************
//  Assembly         : CleanArchitecture.Api.UnitTests
//  Author           :  cmalagoncmalagon
//  Created          : 01-11-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-11-2025
//  ****************************************************************
//  <copyright file="PropertiesControllerTest.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//



using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Millon.TecnicalTest.RealEstate.Api.Controllers.Properties;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Owners;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Properties;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Properties;
using Millon.TecnicalTest.RealEstate.Application.Common.Options;
using Millon.TecnicalTest.RealEstate.Common.Application.Filtering;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;
using Millon.TecnicalTest.RealEstate.Domain.Common.Errors.Properties;
using Moq;

namespace Millon.TecnicalTest.RealEstate.Api.UnitTests.Controllers.Properties
{
    public class PropertiesControllerTest
    {
        private readonly Mock<IPropertyServices> _propertyserviceMock;
        private readonly Mock<IOptions<ApplicationOptions>> _applicationOptionsMock;

        public PropertiesControllerTest()
        {
            _propertyserviceMock = new Mock<IPropertyServices>(MockBehavior.Strict);
            _applicationOptionsMock = new Mock<IOptions<ApplicationOptions>>(MockBehavior.Strict);
        }

        [Fact]
        public async Task CreatePropertyShouldAddThePropertyAsync()
        {
            // Arrange
            PropertyCreateRequest propertyCreateRequest = new PropertyCreateRequest
            {
                Name = "Property Name",
                Address = "Property Address",
                CodeInternal = "Property CodeInternal",
                Price = 120000000,
                Year = 2000,
                IdOwner = 1
            };
            _propertyserviceMock.Setup(x => x.CreatePropertyAsync(propertyCreateRequest, default))
                .ReturnsAsync(new PropertyResponse
                {
                    Id = 1,
                    Name = "Property Name",
                    Address = "Property Address",
                    CodeInternal = "Property CodeInternal",
                    Price = 120000000,
                    Year = 2000,
                    IdOwner = 1,
                    Owner = new OwnerResponse
                    {
                        Id = 1,
                        Name = "Carlos Malagón",
                        Address = "Calle 66C",
                        Photo = "cafemaca.png",
                        Birthday = new DateOnly(1970, 6, 26)
                    }
                }
                );

            // Act
            var controller = new PropertiesController(_propertyserviceMock.Object, _applicationOptionsMock.Object);
            var result = await controller.CreateProperty(propertyCreateRequest);

            //Assert
            var okResult = Assert.IsType<CreatedAtActionResult>(result);
            var item = Assert.IsType<PropertyResponse>(okResult.Value);
            Assert.Equal(1, item.Id);

        }

        [Fact]
        public async Task AddImagePropertyShouldAddTheImagePropertyAsync()
        {
            // Arrange
            PropertyImageCreateRequest propertyImageCreateRequest = new PropertyImageCreateRequest
            {
                File = "AddNewImage.png",
                Enabled = true
            };
            _propertyserviceMock.Setup(x => x.AddImageAsync(1,propertyImageCreateRequest, default))
                .ReturnsAsync(true);

            // Act
            var controller = new PropertiesController(_propertyserviceMock.Object, _applicationOptionsMock.Object);
            var result = await controller.AddImage(1,propertyImageCreateRequest);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var item = Assert.IsType<bool>(okResult.Value);
            Assert.True(item);

        }

        [Fact]
        public async Task UpdatePropertyShouldChangeThePropertyWhenExistAsync()
        {
            // Arrange
            PropertyUpdateRequest propertyUpdateRequest = new PropertyUpdateRequest
            {
            };
            _propertyserviceMock.Setup(x => x.UpdateAsync(1, propertyUpdateRequest, default))
                .ReturnsAsync(true);

            // Act
            var controller = new PropertiesController(_propertyserviceMock.Object, _applicationOptionsMock.Object);
            var result = await controller.UpdateProperty(1, propertyUpdateRequest);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var item = Assert.IsType<bool>(okResult.Value);
            Assert.True(item);

        }

        [Fact]
        public async Task UpdatePropertyShouldNotChangeThePropertyWhenNotExistAsync()
        {
            // Arrange
            PropertyUpdateRequest propertyUpdateRequest = new PropertyUpdateRequest
            {
            };
            _propertyserviceMock.Setup(x => x.UpdateAsync(1, propertyUpdateRequest, default))
                .ReturnsAsync(false);

            // Act
            var controller = new PropertiesController(_propertyserviceMock.Object, _applicationOptionsMock.Object);
            var result = await controller.UpdateProperty(1, propertyUpdateRequest);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var item = Assert.IsType<bool>(okResult.Value);
            Assert.False(item);

        }

        [Fact]
        public async Task ChangePricePropertyShouldChangeThePricePropertyAsync()
        {
            // Arrange
            PropertyUpdatePriceRequest propertyUpdatePriceRequest = new PropertyUpdatePriceRequest
            {
                Price = 300000000
            };
            _propertyserviceMock.Setup(x => x.UpdatePriceAsync(1, propertyUpdatePriceRequest, default))
                .ReturnsAsync(true);

            // Act
            var controller = new PropertiesController(_propertyserviceMock.Object, _applicationOptionsMock.Object);
            var result = await controller.UpdatePrice(1, propertyUpdatePriceRequest);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var item = Assert.IsType<bool>(okResult.Value);
            Assert.True(item);

        }

        /// <summary>
        /// <MethodName>_should_<expectation>_when_<condition>
        /// nameOfMethodBeingTested_Scenario_ExpectedBehaviour
        /// </summary>
        [Fact]
        public async Task GetPropertyShouldGetthepropertyWhenIdexistAsync()
        {
            // Arrange
            _propertyserviceMock.Setup(x => x.SelectPropertyByIdAsync(1, default))
                .ReturnsAsync(new PropertyResponse
                {
                    Id = 1,
                    Name = "Finca La Ponderosa",
                    Address = "Vereda Playa Alta - Florida",
                    CodeInternal = "FINCA",
                    Price = 120000000,
                    Year = 2000,
                    IdOwner = 1,
                    Owner = new OwnerResponse
                    {
                        Id = 1,
                        Name = "Carlos Malagón",
                        Address = "Calle 66C",
                        Photo = "cafemaca.png",
                        Birthday = new DateOnly(1970, 6, 26)
                    }
                }
                );

            // Act
            var controller = new PropertiesController(_propertyserviceMock.Object, _applicationOptionsMock.Object);
            var result = await controller.GetProperty(1);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var item = Assert.IsType<PropertyResponse>(okResult.Value);
            Assert.Equal(1, item.Id);

        }

        [Fact]
        public async Task GetPropertyShouldGetErrorWhenIdNonexistAsync()
        {
            // Arrange
            _propertyserviceMock.Setup(x => x.SelectPropertyByIdAsync(0, default))
                .ReturnsAsync(PropertyErrors.NotFound(0)
                );

            // Act
            var controller = new PropertiesController(_propertyserviceMock.Object, _applicationOptionsMock.Object);
            var result = await controller.GetProperty(0);

            //Assert
            var errorResult = Assert.IsType<NotFoundObjectResult>(result);
            var item = Assert.IsType<DomainError>(errorResult.Value);
            Assert.Equal(PropertyErrors.NotFound(0).ErrorCode, item.ErrorCode);

        }

        [Fact]
        public async Task GetPagingPropertyShouldGetthepropertyAsync()
        {
            // Arrange
            SearchQueryParameters searchQueryParameters = new SearchQueryParameters(null,null,null,1,10);

            PagedList<PropertyResponse> pagedList = new PagedList<PropertyResponse>();
            pagedList.Items = new List<PropertyResponse>();
            pagedList.Items.Add(
                new PropertyResponse
                {
                    Id = 1,
                    Name = "Finca La Ponderosa",
                    Address = "Vereda Playa Alta - Florida",
                    CodeInternal = "FINCA",
                    Price = 120000000,
                    Year = 2000,
                    IdOwner = 1,
                    Owner = new OwnerResponse
                    {
                        Id = 1,
                        Name = "Carlos Malagón",
                        Address = "Calle 66C",
                        Photo = "cafemaca.png",
                        Birthday = new DateOnly(1970, 6, 26)
                    }
                }
                );
            _propertyserviceMock.Setup(x => x.SelectAllProperties(searchQueryParameters, default))
                .ReturnsAsync(pagedList
                );

            // Act
            var controller = new PropertiesController(_propertyserviceMock.Object, _applicationOptionsMock.Object);
            var result = await controller.GetPagingProperty(searchQueryParameters, default);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var item = Assert.IsType<List<PropertyResponse>>(okResult.Value);
            Assert.Equal(1, item.Count);

        }
    }
}
