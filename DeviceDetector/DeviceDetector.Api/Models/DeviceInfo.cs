using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoranApp.Models
{
    public class DeviceInfo
    {
        public string Device { get; set; }
        public string UserAgent { get; set; }
        public string OS { get; set; }
        public string OsVersion { get; set; }
        public string Browser { get; set; }
        public string BrowserVersion { get; set; }
        public string DeviceType { get; set; }
        public string Orientation { get; set; }
    }
}
