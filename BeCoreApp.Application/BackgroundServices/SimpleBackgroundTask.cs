using BeCoreApp.Infrastructure.Tasks.Scheduling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeCoreApp.Application.BackgroundServices
{
    public class SimpleBackgroundTask : IScheduledTask
    {
        private readonly object _lock = new object();

        //watch more rules here: https://en.wikipedia.org/wiki/Cron#CRON_expression
        //expression */5 * * * * represents a schedule of every 5 minutes,
        //the cron expression * * * * * defines a minute-by - minute schedule,
        //and the cron expression 50 12 * * * means 12:50 PM daily.
        public string Schedule { get; set; } = $"*/1 * * * *";


        public SimpleBackgroundTask() { }
       
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                lock(_lock)
                {
                    //Todo: Your job here

                    var a = 1;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
