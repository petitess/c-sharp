using Microsoft.Data.SqlClient;

namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "sql-x-prod-01.database.windows.net";
                builder.UserID = "azadmin";
                builder.Password = "x";
                builder.InitialCatalog = "sqldb-weather-01";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("Id " + "First Name" + " Last Name");
                    Console.WriteLine("=========================================\n");

                    String sql = "SELECT * from [sqldb-weather-01].dbo.Employees";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                                
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}
