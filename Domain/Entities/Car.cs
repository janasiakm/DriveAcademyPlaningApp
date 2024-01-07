namespace Domain.Entities
{
    public class Car : Audity
    {
        public int CarId { get; set; }
        public string Mark { get; set; } = "";
        public string Model { get; set; } = "";
        public string RejestractionNumber { get; set; } = "";
        public int ProductionYear { get; set; }

    }
}
