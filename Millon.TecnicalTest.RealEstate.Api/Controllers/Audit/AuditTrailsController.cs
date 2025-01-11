﻿// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Api
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 09-2023-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 09-20-2024
//  ****************************************************************
//  <copyright file="AuditTrailsController.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Audit;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services;
using Millon.TecnicalTest.RealEstate.Application.Common.Options;
using Millon.TecnicalTest.RealEstate.Common.Api.Common;
using Millon.TecnicalTest.RealEstate.Common.Api.Extensions;
using Millon.TecnicalTest.RealEstate.Common.Application.Filtering;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;

namespace Millon.TecnicalTest.RealEstate.Api.Controllers.Audit
{
    /// <summary>
    /// Controller de los endpoints para AuditTrails
    /// </summary>
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class AuditTrailsController : ControllerBase // ControllerBase is a base class for MVC controller without view support.
    {
        private readonly IAuditTrailServices _auditTrailServices;
        private readonly IOptions<ApplicationOptions> _applicationOptions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auditTrailServices"></param>
        public AuditTrailsController(IAuditTrailServices auditTrailServices, IOptions<ApplicationOptions> applicationOptions)
        {
            _auditTrailServices = auditTrailServices;
            _applicationOptions = applicationOptions;
        }

        /// <summary>
        /// Get a single auditTrail
        /// </summary>
        /// <param name="id">The id AuditTrail</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AuditTrailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAuditTrail(Guid id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _auditTrailServices.SelectAuditTrailByIdAsync(id, cancellationToken).ConfigureAwait(false);

            return result.Match<IActionResult>(
                m => Ok(m),
                fail => NotFound(fail)
                );
        }

        /// <summary>
        /// Get all auditTrails
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<AuditTrailResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAuditTrails(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var auditTrailsResult = await _auditTrailServices.SelectAllAuditTrails(cancellationToken);

            return auditTrailsResult.Match<IActionResult>(
                m => Ok(m),
                fail => NotFound(fail)
                );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchQueryParameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("Paging", Name = "AuditTrailsPaging")]
        [ProducesResponseType(typeof(IEnumerable<AuditTrailResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApplicationError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPagingAuditTrails([FromQuery] SearchQueryParameters searchQueryParameters, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (searchQueryParameters.PageIndex <= 0 || searchQueryParameters.PageSize <= 0)
                return BadRequest(ApplicationErrors.ValidPropertiesPage(searchQueryParameters.PageIndex, searchQueryParameters.PageSize));

            var auditTrailsResult = await _auditTrailServices.SelectAllAuditTrails(searchQueryParameters, cancellationToken);

            // Add pagination metadata to headers
            var pagedItems = auditTrailsResult.Match<PagedList<AuditTrailResponse>>(
                m => m,
                fail => null
            );
            this.AddPaginationMetadata(pagedItems, searchQueryParameters);

            return auditTrailsResult.Match<IActionResult>(
                m => Ok(m.Items),
                fail => NotFound(fail)
                );
        }
    }

}
