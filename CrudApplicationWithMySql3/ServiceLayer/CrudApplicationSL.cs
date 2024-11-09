using CrudApplicationWithMySql3.CommonLayer.Model;
using CrudApplicationWithMySql3.RepositoryLayer;

namespace CrudApplicationWithMySql3.ServiceLayer
{
    public class CrudApplicationSL : ICrudApplicationSL
    {
        private readonly ICrudApplicationRL _crudApplicationRL;

        public CrudApplicationSL(ICrudApplicationRL crudApplicationRL)
        {
            _crudApplicationRL = crudApplicationRL;
        }

        public AddInformationResponse AddInformation(AddInformationRequest request)
        {
            return _crudApplicationRL.AddInformation(request);
        }

        public List<AddInformationResponse> GetAllInformation()
        {
            return _crudApplicationRL.GetAllInformation();
        }

        public DeleteInformationResponse DeleteInformation(int id)
        {
            return _crudApplicationRL.DeleteInformation(id);
        }

        public UpdateInformationResponse UpdateInformation(UpdateInformationRequest request)
        {
            return _crudApplicationRL.UpdateInformation(request);
        }

        public GetInformationResponse GetInformationById(int id)
        {
            return _crudApplicationRL.GetInformationById(id);
        }
    }
}
