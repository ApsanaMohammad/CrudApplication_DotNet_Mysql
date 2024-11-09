using CrudApplicationWithMySql3.CommonLayer.Model;

namespace CrudApplicationWithMySql3.RepositoryLayer
{
    public interface ICrudApplicationRL
    {
        AddInformationResponse AddInformation(AddInformationRequest request);
        List<AddInformationResponse> GetAllInformation();
        DeleteInformationResponse DeleteInformation(int id);  // Add method for Delete
        UpdateInformationResponse UpdateInformation(UpdateInformationRequest request);  // Add method for Update
        GetInformationResponse GetInformationById(int id);  // Add method for GetById
    }
}
