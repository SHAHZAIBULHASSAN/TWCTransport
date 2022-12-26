using TWCTransport.Business;
using TWCTransport.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace TWCTransport.Controllers
{
    [Route("api/[controller]")]
  
    public class SchoolController : ControllerBase
    {
        readonly ISchool schoolmanager;
       // readonly IOptionSetManager OptionSetManager;

        public SchoolController(ISchool school)
        {
            this.schoolmanager = school;
            
        }


        [HttpGet("api")]
        // [Microsoft.AspNetCore.Mvc.Route("api/school")]
        public async Task<List<School>> GetListAsync() => await this.schoolmanager.GetSchoolListAsync();
      //  public async Task<List<School>> GetSchoolListAsync() => await this.schoolmanager.();
        

        //[HttpGet("AllOptionset/{entityName}/{osName}")]
        //public async Task<List<OptionSetModel>> GetOSListAsync(string entityName, string osName) => await this.OptionSetManager.GetListAsync(entityName, osName);

        //// POST api/<ResversationController>
        //[HttpPut("{id}")]
        //public async Task UpdateAsync([FromBody] TRReqModel detail) => await this.transportRequestManager.UpdateAsync(detail);

        //[HttpDelete("{id}")]
        //public async Task Deleteasync([FromRoute] Guid id) => await this.transportRequestManager.DeleteAsync(id);

        //[HttpPost("op")]
        //public async Task<OptionSetModel> CreateOptionsetAsync([FromBody] OptionSetModel detail)
        //{

        //    return await this.OptionSetManager.CreateAsync(detail);
        //}
        //[HttpPost]
        //public async Task<TRReqModel> CreateAsync([FromBody] TRReqModel detail)
        //{

        //    return await this.transportRequestManager.CreateAsync(detail);
        //}

    }
}
