// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-09-2025
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-09-2025
//  ****************************************************************
//  <copyright file="CurrentSessionProvider.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//



using Microsoft.AspNetCore.Http;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services;
using System.Security.Claims;

namespace Millon.TecnicalTest.RealEstate.Application.UseCases.Users
{
    public class CurrentSessionProvider : ICurrentSessionProvider
    {
        private readonly Guid? _currentUserId;

        public CurrentSessionProvider(IHttpContextAccessor accessor)
        {
            var userId = accessor.HttpContext?.User.FindFirstValue("userid");
            if (userId is null)
            {
                return;
            }

            _currentUserId = Guid.TryParse(userId, out var guid) ? guid : null;
        }

        public Guid? GetUserId() => _currentUserId;
    }
}
