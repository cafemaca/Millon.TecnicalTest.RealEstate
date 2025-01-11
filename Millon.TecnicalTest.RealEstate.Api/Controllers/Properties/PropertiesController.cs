// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Api
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-10-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-10-2025
//  ****************************************************************
//  <copyright file="PropertiesController.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Properties;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Properties;
using Millon.TecnicalTest.RealEstate.Application.Common.Options;
using Millon.TecnicalTest.RealEstate.Common.Api.Common;
using Millon.TecnicalTest.RealEstate.Common.Api.Extensions;
using Millon.TecnicalTest.RealEstate.Common.Application.Filtering;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;

namespace Millon.TecnicalTest.RealEstate.Api.Controllers.Properties
{
    /// <summary>
    /// Controller de los endpoints para Properties
    /// </summary>
    [ApiVersion("1")]
    [ApiVersion("2")]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class PropertiesController : ControllerBase // ControllerBase is a base class for MVC controller without view support.
    {
        private readonly IPropertyServices _propertyServices;
        private readonly IOptions<ApplicationOptions> _applicationOptions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyServices"></param>
        public PropertiesController(IPropertyServices propertyServices, IOptions<ApplicationOptions> applicationOptions)
        {
            _propertyServices = propertyServices;
            _applicationOptions = applicationOptions;
        }

        /// <summary>
        /// Create a new property 
        /// </summary>
        /// <param name="propertyRequest">Property</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The new Property Created.</returns>
        [MapToApiVersion("1")]
        [HttpPost]
        [ProducesResponseType(typeof(PropertyResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IEnumerable<DomainError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProperty([FromBody] PropertyCreateRequest propertyRequest, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _propertyServices.CreatePropertyAsync(propertyRequest, cancellationToken);

            return result.Match<IActionResult>(
                m => CreatedAtAction(nameof(GetProperty), new { id = m.Id }, m),
                fail => BadRequest(fail)
                );
        }

        /// <summary>
        /// Get a single property
        /// </summary>
        /// <param name="id">The id Property</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [MapToApiVersion("1")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PropertyResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProperty(int id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _propertyServices.SelectPropertyByIdAsync(id, cancellationToken).ConfigureAwait(false);

            return result.Match<IActionResult>(
                m => Ok(m),
                fail => NotFound(fail)
                );
        }

        /// <summary>
        /// Get all properties
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [MapToApiVersion("1")]
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<PropertyResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProperty(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var propertiesResult = await _propertyServices.SelectAllProperties(cancellationToken);

            return propertiesResult.Match<IActionResult>(
                m => Ok(m),
                fail => NotFound(fail)
                );
        }

        /// <summary>
        /// It brings a paginated list of the properties according to the desired criteria and order, passed in the parameters.
        /// </summary>
        /// <param name="searchQueryParameters">Search Criteria</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        [MapToApiVersion("1")]
        [HttpGet("Paging", Name = "PropertyPaging")]
        [ProducesResponseType(typeof(IEnumerable<PropertyResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApplicationError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPagingProperty([FromQuery] SearchQueryParameters searchQueryParameters, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (searchQueryParameters.PageIndex <= 0 || searchQueryParameters.PageSize <= 0)
                return BadRequest(ApplicationErrors.ValidPropertiesPage(searchQueryParameters.PageIndex, searchQueryParameters.PageSize));

            var propertiesResult = await _propertyServices.SelectAllProperties(searchQueryParameters, cancellationToken);

            // Add pagination metadata to headers
            var pagedItems = propertiesResult.Match<PagedList<PropertyResponse>>(
                m => m,
                fail => null
            );
            this.AddPaginationMetadata(pagedItems, searchQueryParameters);

            return propertiesResult.Match<IActionResult>(
                m => Ok(m.Items),
                fail => NotFound(fail)
                );
        }

        /// <summary>
        /// Update a property
        /// </summary>
        /// <param name="id">The Id Property</param>
        /// <param name="propertyRequest">The new Data Property</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [MapToApiVersion("1")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<DomainError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProperty(int id, [FromBody] PropertyUpdateRequest propertyRequest, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _propertyServices.UpdateAsync(id, propertyRequest, cancellationToken).ConfigureAwait(false);

            return result.Match<IActionResult>(
                m => Ok(m),
                fail => BadRequest(fail)
                );
        }

        /// <summary>
        /// Update the Property Price.
        /// </summary>
        /// <param name="id">Property Id</param>
        /// <param name="propertyRequest">New Property Price</param>
        /// <param name="cancellationToken">Cancellantion Token</param>
        /// <returns></returns>
        [MapToApiVersion("1")]
        [HttpPut("{id}/UpdatePrice", Name = "UpdatePrice")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<DomainError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePrice([FromRoute] int id, [FromBody] PropertyUpdatePriceRequest propertyRequest, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _propertyServices.UpdatePriceAsync(id, propertyRequest, cancellationToken).ConfigureAwait(false);

            return result.Match<IActionResult>(
                m => Ok(m),
                fail => BadRequest(fail)
                );
        }

        /// <summary>
        /// Addd a new Image to the Property.
        /// </summary>
        /// <param name="id">Property Id</param>
        /// <param name="propertyRequest">New Property Price</param>
        /// <param name="cancellationToken">Cancellantion Token</param>
        /// <returns></returns>
        [MapToApiVersion("1")]
        [HttpPut("{id}/AddImage", Name = "AddImage")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<DomainError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddImage([FromRoute] int id, [FromBody] PropertyImageCreateRequest propertyImageCreateRequest, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _propertyServices.AddImageAsync(id, propertyImageCreateRequest, cancellationToken).ConfigureAwait(false);

            return result.Match<IActionResult>(
                m => Ok(m),
                fail => BadRequest(fail)
                );
        }

        /// <summary>
        /// Delete a property
        /// </summary>
        /// <param name="id">The Ide Property</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [MapToApiVersion("1")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProperty(int id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _propertyServices.DeletePropertyAsync(id, cancellationToken);

            return result.Match<IActionResult>(
                m => Ok(m),
                fail => NotFound(fail)
                );
        }
    }

}
