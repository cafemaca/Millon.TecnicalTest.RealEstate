﻿using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Millon.TecnicalTest.RealEstate.Application.Common.Interfaces.Services;

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
