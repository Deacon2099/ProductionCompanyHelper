namespace ProductionProcessCompanion.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TransportCost { get; set; }
        public double CostOfWorkingHour { get; set; }
        public virtual SearchHistory SearchHistory { get; set; }
    }
}
