//using Core.Models.Domain;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Data
//{
//    public class SaveChangesWithIdentityInsert
//    {
//        public async Task InsertCourseWithIdentityInsert()
//        {
//            string connectionString = "your_connection_string_here";

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                SqlCommand command = new SqlCommand();
//                command.Connection = connection;

//                // Turn IDENTITY_INSERT ON
//                command.CommandText = "SET IDENTITY_INSERT Course ON";
//                command.ExecuteNonQuery();

//                // Perform your INSERT operation here
//                command.CommandText = $"INSERT INTO Course (Id, [Subject], [CreatedDate], [CreatedBy], [UpdatedBy], [UpdatedDate]) VALUES ('{course.Id}', '{course.Subject}', '{course.CreatedDate}', '{course.CreatedBy}', '{course.UpdatedBy}', '{course.UpdatedDate}')";
//                command.ExecuteNonQuery();

//                // Turn IDENTITY_INSERT OFF
//                command.CommandText = "SET IDENTITY_INSERT Course OFF";
//                command.ExecuteNonQuery();

//                connection.Close();
//            }
//        }
//    }
//}
