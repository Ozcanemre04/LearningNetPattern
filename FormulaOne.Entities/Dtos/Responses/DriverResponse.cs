using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulaOne.Entities.Dtos.Responses
{
    public class DriverResponse : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int DriverNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}