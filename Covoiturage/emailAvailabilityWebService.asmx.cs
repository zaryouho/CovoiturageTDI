using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Configuration;

namespace Covoiturage
{
    /// <summary>
    /// Summary description for emailAvailabilityWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EmailAvailabilityWebService : System.Web.Services.WebService
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["HamzaConnectionString"].ConnectionString;
        private static readonly string query = @"select count(id) from [dbo].[utilisateur] where email = @userEmail ";
        bool emailAvailable = false;
        [WebMethod]
        public void checkUserNameAvailability(string userEmail)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@userEmail",
                        Value = userEmail
                    });
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    emailAvailable = Convert.ToBoolean(command.ExecuteScalar());
                }
                connection.Close();
            }

            User user = new User
            {
                email = userEmail,
                isAvailable = emailAvailable
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Context.Response.Write(serializer.Serialize(user));
        }
    }
}
