using BeCoreApp.Application.ViewModels;
using BeCoreApp.Application.ViewModels.Blog;
using BeCoreApp.Application.ViewModels.Common;
using BeCoreApp.Application.ViewModels.Product;
using BeCoreApp.Application.ViewModels.System;
using System.Collections.Generic;

namespace BeCoreApp.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            HomeBlogs = new List<BlogViewModel>();
            ChartRounds = new List<ChartRoundViewModel>();
        }
        public List<BlogViewModel> HomeBlogs { get; set; }
        public NotifyViewModel Notify { get; set; }
        public List<ChartRoundViewModel> ChartRounds { get; set; }
    }
}
