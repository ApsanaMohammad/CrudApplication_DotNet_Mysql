using CrudApplicationWithMySql3.CommonLayer.Model;

namespace CrudApplicationWithMySql3.ServiceLayer
{
    public interface ICrudApplicationSL
    {
        AddInformationResponse AddInformation(AddInformationRequest request);
        List<AddInformationResponse> GetAllInformation(); // Method for getting all records
        DeleteInformationResponse DeleteInformation(int id);  // Add this method
        UpdateInformationResponse UpdateInformation(UpdateInformationRequest request);
        GetInformationResponse GetInformationById(int id);
    }
}
