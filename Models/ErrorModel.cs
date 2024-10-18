using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Hunting_App_System.Models {
    public class ErrorModel 
    {
        public int code { get; set; }

        public string message { get; set; }

        public List<ErrorModel> errors { get; set; }
    }
}
