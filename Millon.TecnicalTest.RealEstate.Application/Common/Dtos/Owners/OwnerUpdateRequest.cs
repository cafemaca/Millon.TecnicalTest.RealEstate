using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Owners
{
    public class OwnerUpdateRequest
    {
        public required int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Address { get; set; } = string.Empty;

        public required string Photo { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
    }
}
