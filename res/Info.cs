using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.res
{
    [Serializable]
    public class Info
    {
        public string? ComputerName { get; set; } = Environment.MachineName;
        public bool IsOnline { get; set; }
        public string? Message { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public override string ToString()
        {
            if (ComputerName is not null)
            {
                return ComputerName;
            }
            return "Unknown";
        }

    }
}
