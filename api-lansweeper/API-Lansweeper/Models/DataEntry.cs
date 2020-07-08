using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Lansweeper.Models
{
    public class DataEntry
    {
        public string Domain { get; set; }
        public string AssetName { get; set; }
        public string UserName { get; set; }
        public string Type { get; set; }
        public DateTime LastSeen { get; set; }
        public string OS { get; set; }
        public string SoftwareName { get; set; }
        public string SoftwareVersion { get; set; }
        public decimal NumberOfCores { get; set; }
        public decimal NumberOfProcessors{ get; set; }
        public string SoftwarePublisher { get; set; }
        public string IPAddress { get; set; }
        public string FQDN { get; set; }
        public string Processor { get; set; }
        public string Model { get; set; }
        public string TotalPhysicalMemory { get; set; }
        public string EncryptionLevel { get; set; }
        public DateTime InstallDate { get; set; }
        public string SerialNumber { get; set; }
        public string Manufacturer { get; set; }
        public DateTime LastPatched { get; set; }
        public string Location { get; set; }
    }
}