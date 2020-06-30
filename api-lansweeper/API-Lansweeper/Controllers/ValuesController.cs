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

                            if (!reader.IsDBNull(1))
                                dataEntry.Domain = reader.GetString(1);

                            if (!reader.IsDBNull(2))
                                dataEntry.AssetName = reader.GetString(2);

                            if (!reader.IsDBNull(3))
                                dataEntry.UserName = reader.GetString(3);

                            if (!reader.IsDBNull(4))
                                dataEntry.Type = reader.GetString(4);

                            if (!reader.IsDBNull(6))
                                dataEntry.LastSeen = reader.GetDateTime(6);

                            if (!reader.IsDBNull(7))
                                dataEntry.OS = reader.GetString(7);

                            if (!reader.IsDBNull(8))
                                dataEntry.SoftwareName = reader.GetString(8);

                            if (!reader.IsDBNull(9))
                                dataEntry.SoftwarePublisher = reader.GetString(9);

                            if (!reader.IsDBNull(10))
                                dataEntry.SoftwareVersion = reader.GetString(10);

                            if (!reader.IsDBNull(11))
                                dataEntry.NumberOfCores = reader.GetDecimal(11);

                            if (!reader.IsDBNull(12))
                                dataEntry.NumberOfProcessors = reader.GetDecimal(12);

                            if (!reader.IsDBNull(13))
                                dataEntry.IPAddress = reader.GetString(13);

                            if (!reader.IsDBNull(14))
                                dataEntry.FQDN = reader.GetString(14);

                            if (!reader.IsDBNull(15))
                                dataEntry.Processor = reader.GetString(15);

                            if (!reader.IsDBNull(16))
                                dataEntry.Model = reader.GetString(16);

                            if (!reader.IsDBNull(17))
                                dataEntry.TotalPhysicalMemory = reader.GetDecimal(17).ToString();

                            if (!reader.IsDBNull(18))
                                dataEntry.EncryptionLevel = reader.GetDecimal(18).ToString();

                            if (!reader.IsDBNull(19))
                                dataEntry.InstallDate = reader.GetDateTime(19);

                            if (!reader.IsDBNull(20))
                                dataEntry.SerialNumber = reader.GetString(20);

                            if (!reader.IsDBNull(22))
                                dataEntry.Manufacturer = reader.GetString(22);

                            if (!reader.IsDBNull(23))
                                dataEntry.LastPatched = reader.GetDateTime(23);

                            if (!reader.IsDBNull(24))
                                dataEntry.Location = reader.GetString(24);

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
