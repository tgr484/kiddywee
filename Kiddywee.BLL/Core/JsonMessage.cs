using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.BLL.Core
{
    public class JsonMessage
    {
        public string Color { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }
        public string Icon { get; set; }

        public object AdditionalData { get; set; }
    }
}
