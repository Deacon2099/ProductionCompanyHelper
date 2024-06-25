using ProductionCompanyHelper.ModelsDTO;

namespace ProductionCompanyHelper.Services.Interfaces
{
    public interface ICalculatorCostService
    {
        OperationResultDTO CalculateCost(string cityName, ModuleListDTO moduleListDTO);
    }
}
