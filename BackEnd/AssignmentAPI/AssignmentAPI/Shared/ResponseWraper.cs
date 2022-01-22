using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentAPI.Shared
{
    public class ResponseWraper
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}