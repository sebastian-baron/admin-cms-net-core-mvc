using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Core.Models.Domains
{
    public class Logs
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public string Exception { get; set; }
        public string Trace { get; set; }
        public string Logger { get; set; }

    }
}
