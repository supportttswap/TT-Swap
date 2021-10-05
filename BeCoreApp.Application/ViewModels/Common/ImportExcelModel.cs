using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeCoreApp.Application.ViewModels.Common
{
    public class ImportExcelModel
    {
        [Required]
        public IFormFile FileUpload { get; set; }
    }

    public class MemberBalanceModel
    {
        public string Email { get; set; }
        public decimal Balance { get; set; }
    }
}
