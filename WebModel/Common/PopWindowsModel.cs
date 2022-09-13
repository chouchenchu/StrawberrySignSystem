using System;
using System.Collections.Generic;
using System.Text;

namespace WebModel.Common
{
    public class PopWindowsModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public bool Isjump { get; set; } = false;

        public string jumpurl { get; set; } = string.Empty;
    }
}
