using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.SystemConfig
{
    public class SystemConfig
    {
        public string DBPath { get; set; } = "";
        public string Version { get; set; } = "V1.0.0.220912";//大版號+db版號+小版號+異動日期
    }
}
