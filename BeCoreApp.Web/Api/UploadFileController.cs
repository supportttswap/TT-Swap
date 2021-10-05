using BeCoreApp.Application.Implementation;
using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.Common;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.EF;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeCoreApp.Web.Api
{
    [ApiController]
    [Authorize]
    [Route("[Controller]/[action]")]
    public class UploadFileController : Controller
    {
        private readonly IUploadFileService _uploadFileService;

        public UploadFileController(IUploadFileService uploadFileService)
        {
            _uploadFileService = uploadFileService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadMemberBalanceFile([FromForm] ImportExcelModel model)
        {

            var isAdmin = User.IsInRole("Admin");
            if (!isAdmin)
                return BadRequest("something went wrong! Please contact administrator!");

            try
            {
                var result = await _uploadFileService.ProcessUpdateInvestBalanceForMembers(model);

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Email, Balance");
                foreach (var member in result.notFoundMember)
                {
                    stringBuilder.AppendLine($"{member.Email},{ member.Balance}");
                }

                stringBuilder.AppendLine($"Sum Updated:, { result.sumUpdated}");

                return File(Encoding.UTF8.GetBytes
                                 (stringBuilder.ToString()), "text/csv", "notFoundMembers.csv");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}
