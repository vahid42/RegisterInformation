using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApi.RegisterInformation.Dto
{
    public class ResultMessage
    {
        public HttpStatusCode httpStatusCode { get; set; }
        public bool Status { get; set; }
        public string Content { get; set; }
        public string Error { get; set; }
    }
}