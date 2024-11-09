using CrudApplicationWithMySql3.CommonLayer.Model;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace CrudApplicationWithMySql3.RepositoryLayer
{
    public class CrudApplicationRL : ICrudApplicationRL
    {
        private readonly IConfiguration _configuration;

        public CrudApplicationRL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AddInformationResponse AddInformation(AddInformationRequest request)
        {
            var response = new AddInformationResponse();
            try
            {
                string connectionString = _configuration.GetConnectionString("MySqlConnection");

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO UserInformation (UserName, EmailID, MobileNumber, Salary, Gender) " +
                                   "VALUES (@UserName, @EmailID, @MobileNumber, @Salary, @Gender)";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserName", request.UserName);
                        cmd.Parameters.AddWithValue("@EmailID", request.EmailID);
                        cmd.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                        cmd.Parameters.AddWithValue("@Salary", request.Salary);
                        cmd.Parameters.AddWithValue("@Gender", request.Gender);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        response.IsSuccess = rowsAffected > 0;
                        response.Message = rowsAffected > 0 ? "Information added successfully." : "Failed to add information.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public List<AddInformationResponse> GetAllInformation()
        {
            List<AddInformationResponse> informationList = new List<AddInformationResponse>();

            try
            {
                string connectionString = _configuration.GetConnectionString("MySqlConnection");

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Id, UserName, EmailID, MobileNumber, Salary, Gender FROM UserInformation";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var information = new AddInformationResponse
                                {
                                    Id = reader.GetInt32("Id"),
                                    UserName = reader.GetString("UserName"),
                                    EmailID = reader.GetString("EmailID"),
                                    MobileNumber = reader.GetString("MobileNumber"),
                                    Salary = reader["Salary"] != DBNull.Value ? Convert.ToInt32(reader["Salary"]) : 0,
                                    Gender = reader.GetString("Gender"),
                                    IsSuccess = true,
                                    Message = "Record found"
                                };

                                informationList.Add(information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                informationList.Add(new AddInformationResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                });
            }

            return informationList;
        }


        public DeleteInformationResponse DeleteInformation(int id)
        {
            var response = new DeleteInformationResponse();
            try
            {
                string connectionString = _configuration.GetConnectionString("MySqlConnection");

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM UserInformation WHERE Id = @Id";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        response.IsSuccess = rowsAffected > 0;
                        response.Message = rowsAffected > 0 ? "Information deleted successfully." : "Failed to delete information.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public UpdateInformationResponse UpdateInformation(UpdateInformationRequest request)
        {
            var response = new UpdateInformationResponse();
            try
            {
                string connectionString = _configuration.GetConnectionString("MySqlConnection");

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE UserInformation SET UserName = @UserName, EmailID = @EmailID, MobileNumber = @MobileNumber, " +
                                   "Salary = @Salary, Gender = @Gender WHERE Id = @Id";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserName", request.UserName);
                        cmd.Parameters.AddWithValue("@EmailID", request.EmailID);
                        cmd.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                        cmd.Parameters.AddWithValue("@Salary", request.Salary);
                        cmd.Parameters.AddWithValue("@Gender", request.Gender);
                        cmd.Parameters.AddWithValue("@Id", request.Id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        response.IsSuccess = rowsAffected > 0;
                        response.Message = rowsAffected > 0 ? "Information updated successfully." : "Failed to update information.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public GetInformationResponse GetInformationById(int id)
        {
            var response = new GetInformationResponse();
            try
            {
                string connectionString = _configuration.GetConnectionString("MySqlConnection");

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM UserInformation WHERE Id = @Id";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                response.Id = reader.GetInt32("Id");
                                response.UserName = reader.GetString("UserName");
                                response.EmailID = reader.GetString("EmailID");
                                response.MobileNumber = reader.GetString("MobileNumber");
                                response.Salary = reader.GetInt32("Salary");
                                response.Gender = reader.GetString("Gender");

                                response.IsSuccess = true;
                                response.Message = "Information retrieved successfully.";
                            }
                            else
                            {
                                response.IsSuccess = false;
                                response.Message = "No information found with the given ID.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
