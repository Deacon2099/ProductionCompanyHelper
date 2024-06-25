using ProductionCompanyHelper.Models;
using ProductionCompanyHelper.ModelsDTO;
using System.Collections.Generic;

namespace ProductionCompanyHelper.Services.Interfaces
{
    public interface IModuleService
    {
        Module GetModuleByName(string moduleName);
        OperationSuccessDTO<List<Module>> GetModules();
        OperationSuccessDTO<Module> AddModule(Module module);
        OperationSuccessDTO<Module> UpdateModule(Module module);
        OperationSuccessDTO<Module> DeleteModule(string name);
    }
}
