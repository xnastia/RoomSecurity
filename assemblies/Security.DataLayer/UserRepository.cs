using System;
using System.Configuration;
using System.Data.SqlClient;
using Security.Entities;
using Security.Entities.DB;

namespace Security.DataLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString = ConfigurationManager
            .ConnectionStrings["DBConnection"]
            .ConnectionString;

        public bool UserExistsByEmailAndPassword(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("email is null");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password is null");

            var userexists = false;
            int numberOfUsers;
            password = HashCalculator.CalculateHash(password);
            var userExistsByEmailAndPassword = "sp_UserExistsByEmailAndPassword";
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(userExistsByEmailAndPassword, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var emailParameter = new SqlParameter("@email", email);
                var passwordParameter = new SqlParameter("@password", password);
                command.Parameters.Add(emailParameter);
                command.Parameters.Add(passwordParameter);
                connection.Open();
                numberOfUsers = (int) command.ExecuteScalar();
            }

            if (numberOfUsers > 0)
                userexists = true;

            return userexists;
        }

        public void AddUser(string firstName, string lastName, string email, string password)
        {
            password = HashCalculator.CalculateHash(password);
            var addUser = "sp_InserUser";

            if (!UserExistsByEmailAndPassword(email, password))
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(addUser, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    var firstNameParameter = new SqlParameter("@firstName", firstName);
                    var lastNameParameter = new SqlParameter("@lastName", lastName);
                    var emailParameter = new SqlParameter("@email", email);
                    var passwordParameter = new SqlParameter("@password", password);
                    command.Parameters.Add(firstNameParameter);
                    command.Parameters.Add(lastNameParameter);
                    command.Parameters.Add(emailParameter);
                    command.Parameters.Add(passwordParameter);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}