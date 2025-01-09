// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Api
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 04-18-2024 
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 04-18-2024
//  ****************************************************************
//  <copyright file="ProgramHelpers.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Millon.TecnicalTest.RealEstate.Common.Application.Validators;

namespace Millon.TecnicalTest.RealEstate.Common.Api.Middleware.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidationExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="exception"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is ValidationException validationException)
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext.Response.WriteAsJsonAsync(new ValidationFailed(validationException.Errors), cancellationToken);

                return true;
            }

            return false;
        }
    }
}
