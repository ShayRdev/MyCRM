namespace my_crm_api.Models
{
    public class Vehicles
    {
        public int VehicleId { get; set; }
        public int UserId { get; set; }
        public string VIN { get; set; }
        public string Make { get; set; }   
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string EngineType { get; set; }
        public int EstimatedLifespanMiles { get; set; }
        public DateTime LifespanEvaluationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
