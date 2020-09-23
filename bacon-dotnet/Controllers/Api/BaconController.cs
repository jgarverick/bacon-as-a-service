using BxAAS.Custom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BxAAS.Controllers.Api
{
    public class BaconController : Controller
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
