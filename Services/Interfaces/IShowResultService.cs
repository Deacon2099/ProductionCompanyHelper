using ProductionCompanyHelper.ModelsDTO;

namespace ProductionCompanyHelper.Services.Interfaces
{
    public interface IShowResultService
    {
        ResultCostDTO PresentResult(string cityName, ModuleListDTO moduleListDTO);
    }
}
