using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using API_Lansweeper.Models;
using System.Web.Configuration;

namespace API_Lansweeper.Controllers
{
    public class ValuesController : ApiController
    {
        string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
        string _connectingString = WebConfigurationManager.AppSettings["ConnectionString"];

        // GET api/values
        public IEnumerable<DataEntry> Get()
        {
            string SQL_FILE = path + "\\default.sql";
            List<DataEntry> data = new List<DataEntry>();

            if (!File.Exists(SQL_FILE))
            {
                return new List<DataEntry>();
            }
            else
            {
                StreamReader reader1 = new StreamReader(SQL_FILE);
                string query = reader1.ReadToEnd();
                reader1.Close();

                using (SqlConnection connection = new SqlConnection(_connectingString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataEntry dataEntry = new DataEntry();
                            dataEntry.Domain = reader.GetString(1);
                            dataEntry.AssetName = reader.GetString(2);

                            if (!reader.IsDBNull(3))
                                dataEntry.UserName = reader.GetString(3);
                            dataEntry.Type = reader.GetString(4);
                            dataEntry.LastSeen = reader.GetDateTime(6);
                            dataEntry.OS = reader.GetString(7);
                            dataEntry.SoftwareName = reader.GetString(8);
                            dataEntry.SoftwarePublisher = reader.GetString(9);
                            dataEntry.SoftwareVersion = reader.GetString(10);
                            dataEntry.NumberOfCores = reader.GetDecimal(11);
                            dataEntry.NumberOfProcessors = reader.GetDecimal(12);
                            data.Add(dataEntry);
                        }
                            
                    }
                    connection.Close();
                }
                return data;
            }
        }
    }
}
