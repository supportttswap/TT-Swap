using BeCoreApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeCoreApp.Extensions;
using System.Security.Claims;
using BeCoreApp.Utilities.Constants;
using BeCoreApp.Application.ViewModels.System;

namespace BeCoreApp.Areas.Admin.Components
{
    public class NotifyViewComponent : ViewComponent
    {
        INotifyService _notifyService;
        public NotifyViewComponent(INotifyService notifyService)
        {
            _notifyService = notifyService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifys = _notifyService.GetLast(3);
            return View(notifys);
        }
    }
}
