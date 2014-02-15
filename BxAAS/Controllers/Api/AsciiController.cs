using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BxAAS.Controllers
{
    public class AsciiController : ApiController
    {
        public object Get()
        {
            return Content(HttpStatusCode.OK, "");
        }
    }
}
