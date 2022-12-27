using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using TWCTransport.Model;
using TWCTransport.Provider;

namespace TWCTransport.Business
{
    public class SchoolManager : ISchool
    {
        readonly ServiceClient client;
        readonly IDataverseProvider dataverseProvider;
        public SchoolManager(IDataverseProvider dataverseProvider)
        {
            this.dataverseProvider = dataverseProvider;
            this.client = this.dataverseProvider.GetServiceClient();
        }
        private static School MapToSchoolDataverse(Entity entity)
        {
            var result = new School();
            result.Id = entity.GetAttributeValue<Guid>("ss_schoolid");
            result.SchoolPostCode = entity.GetAttributeValue<string>("ss_postcode");
            result.SchoolAnalysisCode = entity.GetAttributeValue<string>("ss_analysiscode");
          //   result.SchoolNumber = entity.GetAttributeValue<int>("ss_schoolnumber");
            result.SchoolName = entity.GetAttributeValue<string>("ss_name");
            //  result.SchoolName = entity.GetAttributeValue<OptionSetValue>("ss_educationtype");


            return result;
        }

        async Task<List<School>> ISchool.GetSchoolListAsync()
        {
            var query = new QueryExpression
            {
                EntityName = "ss_school",
                ColumnSet = new ColumnSet(true),

            };

            var entityCollection = await client.RetrieveMultipleAsync(query);
            var list = entityCollection.Entities.Select(entity => MapToSchoolDataverse(entity)).ToList();


            return list;

        }


    }
}








