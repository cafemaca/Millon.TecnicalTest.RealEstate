﻿// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Application
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 04-18-2024 
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 04-18-2024
//  ****************************************************************
//  <copyright file="ValidationFailed.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using FluentValidation.Results;

namespace Millon.TecnicalTest.RealEstate.Common.Application.Validators
{
    public record ValidationFailed(IEnumerable<ValidationFailure> Errors)
    {
        public ValidationFailed(ValidationFailure error) : this([error])
        {

        }
    }
}
