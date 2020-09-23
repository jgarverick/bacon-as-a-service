using System;
using System.Text;
using System.Threading.Tasks;

namespace BxAAS.Custom
{
    public class Bacon
    {
        public static BaconResult Cook(BaconEventArgs args)
        {
            BaconResult result = new BaconResult();
            result.Title = "Cook";
            if (args.Weight.HasValue && args.Weight >= 10)
            {
                result.Message = "Bacon Coma.";
                result.ImageSource = "http://4.bp.blogspot.com/_OWrFtKbFFq4/TUMdaZ6RbdI/AAAAAAAAAWI/CDQwC_ddzBs/s1600/200px-HomerBacon.jpg";
                return result;
            }
            // So now the fun begins.  Need to figure out what you're using to cook with first.  Unless you're using metric.
            if (args.UseMetricWeight)
            {
                result.Message = "Go brine your bacon, you fucking pansy.";
                result.Outcome = CookingResultCode.Soggy;
                result.ImageSource = "http://upload.wikimedia.org/wikipedia/commons/6/68/Canada_flag_halifax_9_-04.JPG";
                return result;
            }
            switch (args.Medium)
            {
                case CookingStyle.FryingPan:
                case CookingStyle.Campfire:
                    // Time should be 10-15 minutes.
                    if (args.CookTime.HasValue)
                    {
                        result.Message = "Yea, that didn't work so well for you.  You might want to try something easier like the microwave.";
                        if (args.CookTime <= 10 && args.CookTime >= 15)
                        {
                            result.Outcome = CookingResultCode.Perfection;
                            result.Message = "Your stovetop skills are impressive.  Perfection.";
                        }
                    }
                    break;
                case CookingStyle.Microwave:
                    // So the magic number here is 3 minutes.
                    result.Message = "Wow. You want to microwave your bacon and forgot to start the microwave.  You are one lazy fuck.";
                    if (args.CookTime.HasValue)
                    {
                        if (args.CookTime == 3)
                        {
                            result.Outcome = CookingResultCode.Perfection;
                            result.Message = "Way to be lazy an nuke your pork.  At least you didn't burn it.";
                        }
                        else if (args.CookTime < 3)
                        {
                            result.Outcome = CookingResultCode.Soggy;
                            result.Message = "Well that's disappointing.  Try longer next time.  Enjoy your limp pork.";
                        }
                        else if (args.CookTime > 3)
                        {
                            // Anything more than six minutes is going to set off the smoke alarm
                            result.Message = "Jesus jumped-up Christ! Why don't you just throw some tin foil in there too!";
                        }
                    }
                    break;
                case CookingStyle.Oven:
                    // So the magic number is 375 for the temp.
                    result.Message = "Don't be a pussy. Just cook your bacon on the stove.  In a frying pan.";
                    break;
                case CookingStyle.Blowtorch:
                    // Estimated time should be about 1 minute.
                    result.Message = "Seems you forgot to light the blowtorch, assbag.";
                            result.Outcome = CookingResultCode.Soggy;
                    if (args.CookTime.HasValue)
                    {
                        if (args.CookTime == 1)
                        {
                            result.Message = "You are a man's man. Unless you're a woman.";
                            result.Outcome = CookingResultCode.Perfection;
                            result.ImageSource = "http://www.chucknorris.com/images/89.jpg";
                        }
                        else if (args.CookTime > 1)
                        {
                            result.Message = "You just burnt your fucking eyebrows off.  Bra-VO.";
                        }
                    }
                    break;
                case CookingStyle.HoboStove:
                    result.Message = "Hobo stove? What the fuck is a hobo stove?";
                    break;
            }
            return result;
        }

        public static async Task<string> Flip()
        {
            string result = await Task.FromResult<string>("Bacon has been flipped.");
            return result;
        }

        public static async Task<string> Prepare(bool separateStrips, bool cutInHalf)
        {
            string result = string.Empty;
            result = await Task.Run<string>(() =>
            {
                StringBuilder sb = new StringBuilder();
                if (separateStrips)
                    sb.AppendLine("Peeling your bacon loaf into nice neat strips.");
                if (cutInHalf)
                    sb.AppendLine("Cutting your bacon in half.");

                return (!separateStrips && !cutInHalf)?"Just toss the whole fucking slab of pork in there.": sb.ToString();

            });
            return result;
        }
    }

    public enum CookingStyle
    {
        FryingPan,
        Oven,
        Microwave,
        Campfire,
        Blowtorch,
        HoboStove
    }

    public enum CookingResultCode
    {
        Perfection,
        Soggy,
        Crispy,
        Burnt,
        Charcoal,
        PrepOnly
    }

    public class BaconResult{
        public CookingResultCode Outcome { get; set; }
        public string Message { get; set; }
        public string ImageSource { get; set; }
        public string Title { get; set; }
}
    public class BaconEventArgs : EventArgs
    {
        public double? Weight { get; set; }
        public int? Temperature { get; set; }
        public int? CookTime { get; set; }
        public CookingStyle Medium { get; set; }
        public bool SeparateStrips { get; set; }
        public bool CutInHalf { get; set; }
        public bool UseMetricWeight { get; set; }
    }
}