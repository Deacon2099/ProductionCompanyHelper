using System.Collections.Generic;
using ProductionCompanyHelper.Models;
using ProductionCompanyHelper.ModelsDTO;

namespace ProductionCompanyHelper.Services.Interfaces
{
    public interface ICityService
    {
        City GetCityByName(string cityName);
        OperationSuccessDTO<IList<City>> GetCities();
        OperationResultDTO UpdateCostOfWorkingHour(string cityName, double workingHourCost);
        OperationResultDTO UpdateTransportCost(string cityName, double transportCost);
        OperationResultDTO AddCity(City city);
        OperationResultDTO DeleteCity(string cityName);
    }
}
