namespace CrudApplicationWithMySql3.CommonLayer.Model
{
    public class GetInformationResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
