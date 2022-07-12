using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace Project.ADO
{
    public class DAO
    {
        public static SqlConnection GetConnection()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string ConStr = config.GetConnectionString("ConStr");
            return new SqlConnection(ConStr);
        }

        public static DataTable GetDataBySql(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand(sql, GetConnection());

                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = command
                };
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;

            }


            return dt;
        }

        public static int ExecuteNonQuery(String sql, object[] parameters = null)
        {
            int dataLineSuccess = -1;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    connection.Open();
                    if (parameters != null)
                    {
                        string[] listPara = sql.Split(' ');
                        int i = 0;
                        foreach (String item in listPara)
                        {

                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameters[i]);
                                i++;
                            }
                        }
                    }
                    dataLineSuccess = command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

            }


            return dataLineSuccess;
        }
    }
}
