using BxAAS.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BxAAS.Controllers.Api
{
    public class BaconController : ApiController
    {
        public BaconResult Post(BaconEventArgs args)
        {
            return Bacon.Cook(args);
        }

        public BaconResult GetPirate()
        {
            return new BaconResult()
            {
                Title = "Bacon of the Sea",
                Message = "Yo ho ho and a pound of applewood smoked bacon."
            };
        }

        public BaconResult Get()
        {
            return new BaconResult()
            {
                Message="You need to give me more information than that."
            };
        }
    }
}
