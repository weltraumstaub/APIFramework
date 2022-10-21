using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIFramework.Models;

namespace APITests.TestingData
{
    
    
    public class ExternalUserData
    {
        public CreateUserRequestDTO UserData { get; set; }
        public string TestName { get; set; }
        public string Description { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
        public bool IsExplicit { get; set; } = false;
        public bool IsIgnored { get; set; } = false;
        public string IgnoreReason { get; set; }
    }
}
