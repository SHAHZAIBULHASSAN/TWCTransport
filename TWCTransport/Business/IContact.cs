using TWCTransport.Model;

namespace TWCTransport.Business
{
    public interface ISchool
    {

        Task<School> GetSchoolByIdAsync(Guid id);
        Task<List<School>> GetSchoolListAsync();

        Task UpdateSchoolAsync(School schooldata);
        Task DeleteSchoolAsync(Guid id);
        Task<School> CreateSchoolAsync(TRReqModel schooldata);
    }
}
