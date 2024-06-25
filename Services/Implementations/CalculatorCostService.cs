using ProductionCompanyHelper.Models;
using ProductionCompanyHelper.ModelsDTO;
using ProductionCompanyHelper.Services.Interfaces;
using System;

namespace ProductionCompanyHelper.Services.Implementations
{
    public class CalculatorCostService : ICalculatorCostService
    {
        private readonly CalculatorContext context;
        private readonly ICityService cityService;
        private readonly IModuleService moduleService;
        private readonly ISearchHistoryService searchHistoryService;

        public CalculatorCostService(CalculatorContext context, ICityService cityService, IModuleService moduleService, ISearchHistoryService searchHistoryService)
        {
            this.context = context;
            this.cityService = cityService;
            this.moduleService = moduleService;
            this.searchHistoryService = searchHistoryService;
        }

        OperationResultDTO ICalculatorCostService.CalculateCost(string cityName, ModuleListDTO moduleListDTO)
        {
            var city = cityService.GetCityByName(cityName);

            if (city == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn't exist" };
            }

            var moduleCost = city.TransportCost;

            foreach(String moduleName in moduleListDTO.ModuleList)
            {
                var module = moduleService.GetModuleByName(moduleName);

                if (module == null)
                {
                    return new OperationErrorDTO { Code = 404, Message = $"Module with name: {moduleName} doesn't exist" };
                }

                moduleCost += module.Price + (module.AssemblyTime * city.CostOfWorkingHour);
            }

            moduleCost *= 1.3;
            
            return new OperationSuccessDTO<ResultCostDTO> {Message = "Success", Result = new ResultCostDTO {Cost = moduleCost, InSearchHistory = false} };
        }
    }
}
