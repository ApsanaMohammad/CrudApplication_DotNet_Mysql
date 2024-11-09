namespace CrudApplicationWithMySql3.CommonLayer.Model
{
    public class UpdateInformationRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }
    }
}
