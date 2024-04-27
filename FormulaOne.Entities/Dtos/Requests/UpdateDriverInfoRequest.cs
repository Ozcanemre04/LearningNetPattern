

namespace FormulaOne.Entities.Dtos.Requests
{
    public class UpdateDriverInfoRequest
    {
        public string? FirstName { get; set; }
        public  string? LastName { get; set; } 
        public int DriverNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}