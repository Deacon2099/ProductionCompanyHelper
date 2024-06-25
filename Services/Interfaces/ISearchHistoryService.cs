using System.Collections.Generic;
using ProductionCompanyHelper.Models;
using ProductionCompanyHelper.ModelsDTO;

namespace ProductionCompanyHelper.Services.Interfaces
{
    public interface ISearchHistoryService
    {
        ResultCostDTO GetSearchHistory (string cityName, ModuleListDTO moduleListDTO);
        OperationSuccessDTO<IList<SearchHistory>> GetSearchHistories();
        OperationResultDTO AddSearchHistory (SearchHistory searchHistory);
    }
}
