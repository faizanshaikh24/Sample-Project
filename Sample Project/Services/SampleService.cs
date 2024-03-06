
using Sample_Project.Model;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Sample_Project.Services

{
    public class SampleService
    {
        private static string dataSource = "sampleserver1994.database.windows.net";
        private static string username = "AdminLogin";
        private static string password = "LoginAdmin1994";
        private static string database = "SampleDB";

        private SqlConnection GetConnection()
        {
            var myBuilder = new SqlConnectionStringBuilder();

            myBuilder.DataSource = dataSource;
            myBuilder.Password = password;
            myBuilder.UserID = username;
            myBuilder.InitialCatalog = database;

            return new SqlConnection(myBuilder.ConnectionString);


        }

        public List<SampleClass> GetSampleData()
        {
            List<SampleClass> sd = new List<SampleClass>();
            SqlConnection con = GetConnection();
            con.Open();
            
            SqlCommand cmd = new SqlCommand("Select * from SampleTable", con);
            
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    SampleClass ss = new SampleClass()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Age = reader.GetString(2)

                    };

                    sd.Add(ss);
                }

            }

            GetConnection().Close();
            return sd;

        }
    }


}
