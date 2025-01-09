// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Api
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-10-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-10-2024
//  ****************************************************************
//  <copyright file="UsuarioController.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Users;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services.Users;
using Millon.TecnicalTest.RealEstate.Application.Common.Options;
using Millon.TecnicalTest.RealEstate.Common.Api.Common;
using Millon.TecnicalTest.RealEstate.Common.Api.Extensions;
using Millon.TecnicalTest.RealEstate.Common.Application.Filtering;
using Millon.TecnicalTest.RealEstate.Common.Application.Pagining;
using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;

namespace Millon.TecnicalTest.RealEstate.Api.Controllers.Users
{
    /// <summary>
    /// Controller de los endpoints para Usuarios
    /// </summary>
    [ApiVersion("1")]
    [ApiVersion("2")]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class UsersController : ControllerBase // ControllerBase is a base class for MVC controller without view support.
    {
        private readonly IUserServices _usuarioServices;
        private readonly IOptions<ApplicationOptions> _applicationOptions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioServices"></param>
        public UsersController(IUserServices usuarioServices, IOptions<ApplicationOptions> applicationOptions)
        {
            _usuarioServices = usuarioServices;
            _applicationOptions = applicationOptions;
        }

        /// <summary>
        /// Create a new usuario 
        /// </summary>
        /// <param name="usuarioRequest">Usuario</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The new Usuario Created.</returns>
        [MapToApiVersion("1")]
        [HttpPost]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IEnumerable<DomainError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUsuario([FromBody] UserCreateRequest usuarioRequest, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _usuarioServices.CreateUsuarioAsync(usuarioRequest, cancellationToken);

            return result.Match<IActionResult>(
                m => CreatedAtAction(nameof(GetUsuario), new { id = m.Id }, m),
                fail => BadRequest(fail)
                );
        }

        /// <summary>
        /// Get a single usuario
        /// </summary>
        /// <param name="id">The id Usuario</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [MapToApiVersion("1")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsuario(string id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _usuarioServices.SelectUsuarioByIdAsync(id, cancellationToken).ConfigureAwait(false);

            return result.Match<IActionResult>(
                m => Ok(m),
                fail => NotFound(fail)
                );
        }

        /// <summary>
        /// Get all usuarios
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [MapToApiVersion("1")]
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<UserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsuario(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var usuariosResult = await _usuarioServices.SelectAllUsuarios(cancellationToken);

            return usuariosResult.Match<IActionResult>(
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
        [MapToApiVersion("2")]
        [HttpGet("Paging", Name = "UsuarioPaging")]
        [ProducesResponseType(typeof(IEnumerable<UserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DomainError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApplicationError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPagingUsuario([FromQuery] SearchQueryParameters searchQueryParameters, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (searchQueryParameters.PageIndex <= 0 || searchQueryParameters.PageSize <= 0)
                return BadRequest(ApplicationErrors.ValidPropertiesPage(searchQueryParameters.PageIndex, searchQueryParameters.PageSize));

            var usuariosResult = await _usuarioServices.SelectAllUsuarios(searchQueryParameters, cancellationToken);

            // Add pagination metadata to headers
            var pagedItems = usuariosResult.Match<PagedList<UserResponse>>(
                m => m,
                fail => null
            );
            this.AddPaginationMetadata(pagedItems, searchQueryParameters);

            return usuariosResult.Match<IActionResult>(
                m => Ok(m.Items),
                fail => NotFound(fail)
                );
        }

        /// <summary>
        /// Update a usuario
        /// </summary>
        /// <param name="id">The Id Usuario</param>
        /// <param name="usuarioRequest">The new Data Usuario</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [MapToApiVersion("1")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<DomainError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUsuario(string id, [FromBody] UserUpdateRequest usuarioRequest, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _usuarioServices.UpdateAsync(id, usuarioRequest, cancellationToken).ConfigureAwait(false);

            return result.Match<IActionResult>(
                m => Ok(m),
                fail => BadRequest(fail)
                );
        }

        /// <summary>
        /// Delete a usuario
        /// </summary>
        /// <param name="id">The Ide Usuario</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [MapToApiVersion("1")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUsuario(string id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _usuarioServices.DeleteUsuarioAsync(id, cancellationToken);

            return result.Match<IActionResult>(
                m => Ok(m),
                fail => NotFound(fail)
                );
        }
    }

}
