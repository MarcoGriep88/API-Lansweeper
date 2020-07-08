using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Lansweeper.Models
{
    public class AssetEntry
    {
        public string AssetName { get; set; }
        public string AssetTypename { get; set; }
        public string IPAddress { get; set; }
        public DateTime LastSeen { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime Warrantydate { get; set; }
        public string OrderNumber { get; set; }
        public string Serialnumber { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Custom3 { get; set; }
        public string Custom4 { get; set; }
        public string Custom5 { get; set; }
        public string Custom6 { get; set; }
        public string Custom7 { get; set; }
        public string Custom8 { get; set; }
        public string Custom9 { get; set; }
        public string Custom10 { get; set; }
        public string Custom11 { get; set; }

        public string Custom12 { get; set; }

        public string Custom13 { get; set; }
        public string Custom14 { get; set; }
        public string Custom15 { get; set; }
        public string Custom16 { get; set; }
        public string Custom17 { get; set; }
        public string Custom18 { get; set; }
        public string Custom19 { get; set; }

        public string Custom20 { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string Building { get; set; }
        public string Branchoffice { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Domain { get; set; }
        public string Username { get; set; }

        public string Userdomain { get; set; }
        public string Scanserver { get; set; }
        public string OScode { get; set; }
        public string FQDN { get; set; }
        public DateTime Firstseen { get; set; }
        public string Mac { get; set; }
        public decimal Uptime { get; set; }
        public decimal Memory { get; set; }
        public string NrProcessors { get; set; }
        public string Processor { get; set; }
        public string ServiceVersion { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string HTTPTitle { get; set; }
        public string HttpServer { get; set; }
        public string HttpsServer { get; set; }
        public string SMTPheader { get; set; }
        public string SnmpOID { get; set; }
        public string FTPheader { get; set; }
        public string Printedpages { get; set; }
        public string Printerstatus { get; set; }
        public string SSHServer { get; set; }
        public string DNSName { get; set; }
        public string SystemSKU { get; set; }
    }
}