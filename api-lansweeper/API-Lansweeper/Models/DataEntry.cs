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
    }
}