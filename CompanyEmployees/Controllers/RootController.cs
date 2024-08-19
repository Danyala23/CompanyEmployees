using Entities.LinkModels;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [Route("api")]
    [ApiController]
    public class RootController(LinkGenerator linkGenerator) : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator = linkGenerator;

        [HttpGet(Name ="GetRoot")]
        public IActionResult GetRoot([FromHeader(Name ="Accept")] string mediaType)
        {
            if (mediaType.Contains("application/vnd.codemaze.apiroot"))
            {
                var list = new List<Link>
                {
                    new Link
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext,nameof(GetRoot),new {}),
                        Rel = "self",
                        Method = "GET",
                    },
                    new Link
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext,"GetCompanies",new {}),
                        Rel = "companies",
                        Method = "GET",
                    },
                    new Link
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext,"CreateCopmany",new {}),
                        Rel = "create_company",
                        Method = "POST",
                    }
                };
                return Ok(list);
            }
            return NoContent();
        }
    }
}
