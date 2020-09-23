using BxAAS.Custom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BxAAS.Controllers
{
    public class BaconController : Controller
    {
        [AcceptVerbs("POST")]
        public ActionResult Cook(BaconEventArgs args)
        {
            var model = Bacon.Cook(args);
            return View("BaconCard", model);
        }
        [AcceptVerbs("GET")]
        public ActionResult Prep(bool useStrips, bool cutIt)
        {
            return View("BaconCard", new BaconResult() { Title="Prep", Message = Bacon.Prepare(useStrips, cutIt).Result });
        }
        //[AcceptVerbs(HttpVerbs.Post|HttpVerbs.Put)]
        public ActionResult Coma()
        {
            return View("BaconCard", Bacon.Cook(new BaconEventArgs() { Weight = 10 }));
        }

        public ActionResult Pirate()
        {
            return View("BaconCard", new BaconResult() { Title = "Bacon of the Sea", Message = "Arr! There be some pork in ye booty!" });
        }

        public ActionResult Flip(int? flipCount)
        {
            var model = new BaconResult() { Title="Flip" };
            model.Message = (!flipCount.HasValue) ? 
                "You didn't tell me how many times to flip the bacon.<br/><br/>Now it's fucking BURNT."
                : string.Format("You've flipped your bacon {0} time(s).", flipCount);

            return View("BaconCard", model);
        }
    }
}