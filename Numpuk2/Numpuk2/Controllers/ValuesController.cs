using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Numpuk2.Domain.Parameters;
using Numpuk2.Queries;
using Numpuk2.Queries.Exceptions;
using Numpuk2.Queries.Models;
using Numpuk2.Queries.Pagination;

namespace Numpuk2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Server ready";
        }

        [HttpGet("examinations")]
        public ActionResult<PagedResult<ExaminationResponse>> GetExaminations([FromQuery] string password, 
            [FromQuery] int page, 
            [FromQuery] int count,
            [FromQuery] double[] age,
            [FromQuery] Gender? gender, 
            [FromQuery] Consistency[] consistency,
            [FromQuery] double[] ph, 
            [FromQuery] ExaminationStatus[] akkermansiaMuciniphila,
            [FromQuery] ExaminationStatus[] faecalibactriumPrausnitzii)
        {
            try
            {
                var service = new ExaminationService(password, "5432");
                var examinations = service.GetAllExaminations(page, count, gender, age, ph, consistency, akkermansiaMuciniphila, faecalibactriumPrausnitzii);

                return examinations;
            }
            catch (AuthorizationException)
            {
                return Unauthorized();                
            }
        }

        [HttpGet("testTypes")]
        public ActionResult<List<string>> GetTestTypes([FromQuery] Family[] families)
        {
            var service = new TestTypeService();
            return service.GetOfType(families);
        }
    }
}
