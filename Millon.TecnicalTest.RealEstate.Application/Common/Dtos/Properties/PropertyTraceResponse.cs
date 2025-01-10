using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millon.TecnicalTest.RealEstate.Application.Common.Dtos.Properties
{
    public class PropertyTraceResponse
    {
        public DateOnly DateSale { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Value { get; set; }
        public double Tax { get; set; }
    }
}
