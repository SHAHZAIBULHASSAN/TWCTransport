using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TWCTransport.Business;
using TWCTransport.Model;

namespace TWCTransport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        readonly ISchool schoolmanager;
        readonly IOptionSetManager OptionSetManager;

        public SchoolController(ISchool schoolmanager, IOptionSetManager optionSetManager)
        {
            this.schoolmanager = schoolmanager;
            OptionSetManager = optionSetManager;
        }
        [HttpGet]
        public async Task<List<School>> GetSchoolListAsync() =>await this.schoolmanager.GetSchoolListAsync();
            

    }
}
