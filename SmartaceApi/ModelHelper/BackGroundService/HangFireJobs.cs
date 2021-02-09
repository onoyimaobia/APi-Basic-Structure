using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartaceApi.ModelHelper.BackGroundService
{
    public class HangFireJobs
    {
        private static void ConfigureHangFireJobs()
        {
            //sample.
            //note: MethodTocall is a method that will run at the specified time.
            //RecurringJob.AddOrUpdate<MethodTocall>(j => j.ToggleBookingActivation()
            //                    , Cron.Daily(), timeZone: TimeZoneInfo.FindSystemTimeZoneById("W. Central Africa Standard Time"));

            //RecurringJob.AddOrUpdate<MethodTocall>(j => j.ToggleBookingActivationAtNoon()
            //                    , Cron.Daily(12, 0), timeZone: TimeZoneInfo.FindSystemTimeZoneById("W. Central Africa Standard Time"));

        }
    }
}
