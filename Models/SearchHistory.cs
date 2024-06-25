namespace ProductionProcessCompanion.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string ModuleName1 { get; set; }
        public string ModuleName2 { get; set; }
        public string ModuleName3 { get; set; }
        public string ModuleName4 { get; set; }
        public string Description {  get; set; }
        public double ProductionCost { get; set; }
    }
}
