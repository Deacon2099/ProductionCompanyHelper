using System.Collections.Generic;
using System.Linq;
using ProductionCompanyHelper.Models;
using ProductionCompanyHelper.ModelsDTO;
using ProductionCompanyHelper.Services.Interfaces;

namespace ProductionCompanyHelper.Services.Implementations
{
    public class SearchHistoryService : ISearchHistoryService
    {
        private readonly CalculatorContext context;
        private readonly IModuleService moduleService;
        private readonly ICityService cityService;

        public SearchHistoryService(CalculatorContext context, IModuleService moduleService, ICityService cityService)
        {
            this.context = context;
            this.moduleService = moduleService;
            this.cityService = cityService;
        }

        public OperationResultDTO AddSearchHistory(SearchHistory searchHistory)
        {
            context.SearchHistory.Add(searchHistory);
            context.SaveChanges();

            return new OperationSuccessDTO<Module> { Message = "Success" };
        }

        OperationSuccessDTO<IList<SearchHistory>> ISearchHistoryService.GetSearchHistories()
        {
            List<SearchHistory> searchHistories = context.SearchHistory.ToList();

            return new OperationSuccessDTO<IList<SearchHistory>> { Message = "Success", Result = searchHistories };
        }

        public ResultCostDTO GetSearchHistory(string cityName, ModuleListDTO moduleListDTO)
        {
            var city = cityService.GetCityByName(cityName);

            if (city == null)
            {
                return new ResultCostDTO { InSearchHistory = false };
            }

            var searchHistoryList = context.SearchHistory.Where(sh => sh.CityId == city.Id);

            if (searchHistoryList == null)
            {
                return new ResultCostDTO { InSearchHistory = false };
            }

            int counterModule = 0;

            foreach (SearchHistory searchHistory in searchHistoryList)
            {
                counterModule = 0;

                foreach (string searchHistoryPar in moduleListDTO.ModuleList)
                {
                    if (searchHistoryPar == searchHistory.ModuleName1 ||
                        searchHistoryPar == searchHistory.ModuleName2 ||
                        searchHistoryPar == searchHistory.ModuleName3 ||
                        searchHistoryPar == searchHistory.ModuleName4)
                    {
                        counterModule++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (moduleListDTO.ModuleList.Count() == ModuleHasValue(searchHistory) && moduleListDTO.ModuleList.Count() == counterModule)
                {
                    return new ResultCostDTO { InSearchHistory = true, Cost = searchHistory.ProductionCost };
                }
            }

            return new ResultCostDTO { InSearchHistory = false };
        }

        private int ModuleHasValue(SearchHistory searchHistory)
        {
            int counter = 0;

            if (!(searchHistory.ModuleName1 == string.Empty))
            {
                counter++;
            }

            if (!(searchHistory.ModuleName2 == string.Empty))
            {
                counter++;
            }

            if (!(searchHistory.ModuleName3 == string.Empty))
            {
                counter++;
            }

            if (!(searchHistory.ModuleName4 == string.Empty))
            {
                counter++;
            }

            return counter;
        }
    }
}
