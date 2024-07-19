using ProductionCompanyHelper.ModelsDTO;
using ProductionCompanyHelper.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Razor.Generator;

namespace ProductionCompanyHelper.Controllers
{
    public class ShowResultController : ApiController
    {
        private readonly IShowResultService showResultService;

        public ShowResultController(IShowResultService showResultService)
        {
            this.showResultService = showResultService;
        }

        [HttpPost]
        [Route("ShowResult/Get")]
        public IHttpActionResult GetCost(ShowResultDTO showResultDTO)
        {
            var result = this.showResultService.PresentResult(showResultDTO.CityName, showResultDTO.ModuleListDTO);

            if (result.Cost == -1)
            {
                return Content<string>(HttpStatusCode.ExpectationFailed, "Error, probably bad module name");
            }

            return Content<ResultCostDTO>(HttpStatusCode.OK, this.showResultService.PresentResult(showResultDTO.CityName, showResultDTO.ModuleListDTO));
        }
    }
}
