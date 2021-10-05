using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeCoreApp.Infrastructure.Tasks.Scheduling
{
    public interface IScheduledTask
    {
        string Schedule { get; set; }

        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
