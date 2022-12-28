using TWCTransport.Model;

namespace TWCTransport.Business
{
   
        public interface ISchool
        {

        Task<List<School>> GetSchoolListAsync();

    }
    

}

