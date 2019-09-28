using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Numpuk2.Domain;
using Numpuk2.Domain.Parameters;
using Numpuk2.Queries;
using Numpuk2.Queries.Pagination;

namespace Numpuk2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public PagedResult<Examination> Get()
        {
            var service = new ExaminationService("", "5433");
            var ph = new double[] { 0.0, 14.0 };
            var consistency = new Consistency[] { Consistency.HALF_LIQUID, Consistency.LIQUID, Consistency.RIGID };
            var examinations = service.GetAllExaminations(1, 20, null, ph, consistency);

            return examinations;
        }

        [HttpGet("testTypes")]
        public ActionResult<List<string>> GetTestTypes([FromQuery] Family[] families)
        {
            var service = new TestTypeService();
            return service.GetOfType(families);
        }
    }
}
