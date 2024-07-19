using ProductionCompanyHelper.Models;
using ProductionCompanyHelper.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductionCompanyHelper.Controllers
{
    public class ModulesController : ApiController
    {
        private readonly IModuleService moduleService;

        public ModulesController(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }

        [HttpGet]
        [Route("Module/GetModules")]
        public IHttpActionResult GetModules()
        {
            return Content<IList<Module>>(HttpStatusCode.OK, moduleService.GetModules().Result);
        }

        [HttpGet]
        [Route("Module/GetModule/{name}")]
        public IHttpActionResult GetModuleByName(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            return Content<Module>(HttpStatusCode.OK, moduleService.GetModuleByName(name));
        }

        [HttpPut]
        [Route("Module/UpdateModule")]
        public IHttpActionResult UpdateModule(Module module)
        {
            return Content<string>(HttpStatusCode.OK, moduleService.UpdateModule(module).Message);
        }

        [HttpPost]
        [Route("Module/AddModule")]
        public IHttpActionResult AddModule(Module module)
        {
            return Content<string>(HttpStatusCode.OK, moduleService.AddModule(module).Message);
        }

        [HttpDelete]
        [Route("Module/DeleteModule/{name}")]
        public IHttpActionResult DeleteModule(string name)
        {
            return Content<string>(HttpStatusCode.OK, moduleService.DeleteModule(name).Message);
        }
    }
}
