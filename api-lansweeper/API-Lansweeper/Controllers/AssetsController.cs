using API_Lansweeper.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace API_Lansweeper.Controllers
{
    public class AssetsController : ApiController
    {
        string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
        string _connectingString = WebConfigurationManager.AppSettings["ConnectionString"];
        // GET: api/Assets
        public IEnumerable<AssetEntry> Get()
        {
            string SQL_FILE = path + "\\allAssets.sql";
            List<AssetEntry> data = new List<AssetEntry>();

            if (!File.Exists(SQL_FILE))
            {
                return new List<AssetEntry>();
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
                            AssetEntry dataEntry = new AssetEntry();

                            if (!reader.IsDBNull(1))
                                dataEntry.AssetName = reader.GetString(1);

                            if (!reader.IsDBNull(2))
                                dataEntry.AssetTypename = reader.GetString(2);

                            if (!reader.IsDBNull(3))
                                dataEntry.IPAddress = reader.GetString(3);

                            if (!reader.IsDBNull(4))
                                dataEntry.LastSeen = reader.GetDateTime(4);

                            if (!reader.IsDBNull(5))
                                dataEntry.PurchaseDate = reader.GetDateTime(5);

                            if (!reader.IsDBNull(6))
                                dataEntry.Warrantydate = reader.GetDateTime(6);

                            if (!reader.IsDBNull(7))
                                dataEntry.OrderNumber = reader.GetString(7);

                            if (!reader.IsDBNull(8))
                                dataEntry.Serialnumber = reader.GetString(8);

                            if (!reader.IsDBNull(9))
                                dataEntry.Custom1 = reader.GetString(9);

                            if (!reader.IsDBNull(10))
                                dataEntry.Custom2 = reader.GetString(10);

                            if (!reader.IsDBNull(11))
                                dataEntry.Custom3 = reader.GetString(11);

                            if (!reader.IsDBNull(12))
                                dataEntry.Custom4 = reader.GetString(12);

                            if (!reader.IsDBNull(13))
                                dataEntry.Custom5 = reader.GetString(13);

                            if (!reader.IsDBNull(14))
                                dataEntry.Custom6 = reader.GetString(14);

                            if (!reader.IsDBNull(15))
                                dataEntry.Custom7 = reader.GetString(15);

                            if (!reader.IsDBNull(16))
                                dataEntry.Custom8 = reader.GetString(16);
                            if (!reader.IsDBNull(17))
                                dataEntry.Custom9 = reader.GetString(17);
                            if (!reader.IsDBNull(18))
                                dataEntry.Custom10 = reader.GetString(18);
                            if (!reader.IsDBNull(19))
                                dataEntry.Custom11 = reader.GetString(19);
                            if (!reader.IsDBNull(20))
                                dataEntry.Custom12 = reader.GetString(20);
                            if (!reader.IsDBNull(21))
                                dataEntry.Custom13 = reader.GetString(21);
                            if (!reader.IsDBNull(22))
                                dataEntry.Custom14 = reader.GetString(22);
                            if (!reader.IsDBNull(23))
                                dataEntry.Custom15 = reader.GetString(23);
                            if (!reader.IsDBNull(24))
                                dataEntry.Custom16 = reader.GetString(24);
                            if (!reader.IsDBNull(25))
                                dataEntry.Custom17 = reader.GetString(25);
                            if (!reader.IsDBNull(26))
                                dataEntry.Custom18 = reader.GetString(26);
                            if (!reader.IsDBNull(27))
                                dataEntry.Custom19 = reader.GetString(27);
                            if (!reader.IsDBNull(28))
                                dataEntry.Custom20 = reader.GetString(28);
                            if (!reader.IsDBNull(29))
                                dataEntry.Location = reader.GetString(29);
                            if (!reader.IsDBNull(30))
                                dataEntry.Department = reader.GetString(30);
                            if (!reader.IsDBNull(31))
                                dataEntry.Building = reader.GetString(31);
                            if (!reader.IsDBNull(32))
                                dataEntry.Branchoffice = reader.GetString(32);
                            if (!reader.IsDBNull(33))
                                dataEntry.Description = reader.GetString(33);
                            if (!reader.IsDBNull(34))
                                dataEntry.Contact = reader.GetString(34);
                            if (!reader.IsDBNull(35))
                                dataEntry.Domain = reader.GetString(35);
                            if (!reader.IsDBNull(36))
                                dataEntry.Username = reader.GetString(36);

                            if (!reader.IsDBNull(37))
                                dataEntry.Userdomain = reader.GetString(37);

                            if (!reader.IsDBNull(38))
                                dataEntry.Scanserver = reader.GetString(38);
                            if (!reader.IsDBNull(39))
                                dataEntry.OScode = reader.GetString(39);
                            if (!reader.IsDBNull(10))
                                dataEntry.FQDN = reader.GetString(10);
                            if (!reader.IsDBNull(41))
                                dataEntry.Firstseen = reader.GetDateTime(41);
                            if (!reader.IsDBNull(42))
                                dataEntry.Mac = reader.GetString(42);
                            if (!reader.IsDBNull(43))
                                dataEntry.Uptime = reader.GetDecimal(43);
                            if (!reader.IsDBNull(44))
                                dataEntry.Memory = reader.GetDecimal(44);
                            if (!reader.IsDBNull(45))
                                dataEntry.NrProcessors = reader.GetDecimal(45).ToString();
                            if (!reader.IsDBNull(46))
                                dataEntry.Processor = reader.GetString(46);
                            //if (!reader.IsDBNull(47))
                            //    dataEntry.LastPatched = reader.GetDateTime(47);

                            if (!reader.IsDBNull(48))
                                dataEntry.Manufacturer = reader.GetString(48);

                            if (!reader.IsDBNull(49))
                                dataEntry.Model = reader.GetString(49);

                            if (!reader.IsDBNull(50))
                                dataEntry.HTTPTitle = reader.GetString(50);

                            if (!reader.IsDBNull(51))
                                dataEntry.HttpServer = reader.GetString(51);

                            if (!reader.IsDBNull(52))
                                dataEntry.HttpsServer = reader.GetString(52);
                            if (!reader.IsDBNull(53))
                                dataEntry.SMTPheader = reader.GetString(53);
                            if (!reader.IsDBNull(54))
                                dataEntry.SnmpOID = reader.GetString(54);
                            if (!reader.IsDBNull(55))
                                dataEntry.FTPheader = reader.GetString(55);
                            if (!reader.IsDBNull(56))
                                dataEntry.Printedpages = reader.GetString(56);
                            if (!reader.IsDBNull(57))
                                dataEntry.Printerstatus = reader.GetDecimal(57).ToString();
                            if (!reader.IsDBNull(58))
                                dataEntry.SSHServer = reader.GetString(58);
                            if (!reader.IsDBNull(59))
                                dataEntry.DNSName = reader.GetString(59);
                            if (!reader.IsDBNull(60))
                                dataEntry.SystemSKU = reader.GetString(60);

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
