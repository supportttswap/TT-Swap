using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.Blog;
using BeCoreApp.Application.ViewModels.Common;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Data.IRepositories;
using BeCoreApp.Infrastructure.Interfaces;
using BeCoreApp.Utilities.Constants;
using BeCoreApp.Utilities.Dtos;
using BeCoreApp.Utilities.Helpers;

namespace BeCoreApp.Application.Implementation
{
    public class NotifyService : INotifyService
    {
        private readonly INotifyRepository _notifyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotifyService(INotifyRepository notifyRepository, IUnitOfWork unitOfWork)
        {
            _notifyRepository = notifyRepository;
            _unitOfWork = unitOfWork;
        }

        public NotifyViewModel Add(NotifyViewModel notifyVm)
        {
            var notify = new Notify
            {
                Name = notifyVm.Name,
                MildContent = notifyVm.MildContent,
                Status = notifyVm.Status,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            _notifyRepository.Add(notify);

            return notifyVm;
        }

        public NotifyViewModel GetDashboard()
        {
            var model = _notifyRepository
                .FindAll(x => x.Status == Status.Active)
                .OrderByDescending(x => x.Id).FirstOrDefault();

            if (model == null)
                return null;

            return new NotifyViewModel
            {
                Id = model.Id,
                Name = model.Name,
                MildContent = model.MildContent,
                Status = model.Status,
                DateCreated = model.DateCreated,
                DateModified = model.DateModified,
            };
        }

        public PagedResult<NotifyViewModel> GetAllPaging(string startDate, string endDate, string keyword, int pageIndex, int pageSize)
        {
            var query = _notifyRepository.FindAll();

            if (!string.IsNullOrWhiteSpace(startDate))
            {
                DateTime start = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                query = query.Where(x => x.DateCreated >= start);
            }

            if (!string.IsNullOrWhiteSpace(endDate))
            {
                DateTime end = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                query = query.Where(x => x.DateCreated <= end);
            }

            if (!string.IsNullOrWhiteSpace(keyword))
                query = query.Where(x => x.Name.ToLower().Contains(keyword.ToLower()));

            var totalRow = query.Count();
            var data = query.OrderByDescending(x => x.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .Select(x => new NotifyViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    MildContent = x.MildContent,
                    Status = x.Status,
                    DateModified = x.DateModified,
                    DateCreated = x.DateCreated
                }).ToList();

            return new PagedResult<NotifyViewModel>()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                Results = data,
                RowCount = totalRow
            };
        }

        public List<NotifyViewModel> GetLast(int top)
        {
            var query = _notifyRepository.FindAll(x => x.Status == Status.Active).Take(top);
            var data = query.OrderByDescending(x => x.Id)
                .Select(x => new NotifyViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    MildContent = x.MildContent,
                    Status = x.Status,
                    DateModified = x.DateModified,
                    DateCreated = x.DateCreated
                }).ToList();

            return data;
        }

        public NotifyViewModel GetById(int id)
        {
            var model = _notifyRepository.FindById(id);
            if (model == null)
                return null;

            return new NotifyViewModel
            {
                Id = model.Id,
                Name = model.Name,
                MildContent = model.MildContent,
                Status = model.Status,
                DateModified = model.DateModified,
                DateCreated = model.DateCreated
            };
        }

        public void Save() => _unitOfWork.Commit();

        public void Update(NotifyViewModel notifyVm)
        {
            var notify = _notifyRepository.FindById(notifyVm.Id);

            notify.Name = notifyVm.Name;
            notify.MildContent = notifyVm.MildContent;
            notify.Status = notifyVm.Status;
            notify.DateModified = DateTime.Now;

            _notifyRepository.Update(notify);
        }

        public void Delete(int id) => _notifyRepository.Remove(id);
    }
}