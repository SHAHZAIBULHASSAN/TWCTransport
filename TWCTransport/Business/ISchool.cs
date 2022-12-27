using TWCTransport.Model;

namespace TWCTransport.Business
{
   
        public interface ISchool
        {


       // string  GetSchoolListAsync();
        Task<List<School>> GetSchoolListAsync();

    }
    

}

