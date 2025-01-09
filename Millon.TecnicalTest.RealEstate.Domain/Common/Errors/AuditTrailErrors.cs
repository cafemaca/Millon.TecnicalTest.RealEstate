﻿using Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions;

namespace Millon.TecnicalTest.RealEstate.Domain.Common.Errors
{
    public class AuditTrailErrors
    {
        #region Bussines Validator Errors
        #endregion

        #region Bussines Errors
        public static DomainError NotFound(Guid id) => new("AuditTrail.NotFound", $"The AuditTrail with Id '{id}' was not found");
        #endregion
    }
}
