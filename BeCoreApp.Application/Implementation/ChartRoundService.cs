using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Data.IRepositories;
using BeCoreApp.Infrastructure.Interfaces;
using BeCoreApp.Utilities.Constants;
using BeCoreApp.Utilities.Dtos;
using BeCoreApp.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeCoreApp.Application.Implementation
{
    public class ChartRoundService : IChartRoundService
    {
        private readonly IChartRoundRepository _chartRoundRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChartRoundService(
            IChartRoundRepository chartRoundRepository,
            IUnitOfWork unitOfWork)
        {
            _chartRoundRepository = chartRoundRepository;
            _unitOfWork = unitOfWork;
        }

        public List<ChartRoundViewModel> GetAll()
        {
            var query = _chartRoundRepository.FindAll();

            var data = query.Select(x => new ChartRoundViewModel()
            {
                Id = x.Id,
                DistributedToken = x.DistributedToken,
                Total = x.Total,
                Type = x.Type,
                DateCreated = x.DateCreated,
                DateUpdated = x.DateUpdated
            }).ToList();

            return data;
        }

        public void Update(ChartRoundViewModel model)
        {
            var chartRound = _chartRoundRepository.FindById(model.Id);

            chartRound.DistributedToken = model.DistributedToken;
            chartRound.DateUpdated = DateTime.Now;
            _chartRoundRepository.Update(chartRound);
        }

        public ChartRoundViewModel GetByType(ChartRoundType type)
        {
            var chartRound = _chartRoundRepository.FindSingle(x => x.Type == type);

            return new ChartRoundViewModel()
            {
                Id = chartRound.Id,
                DistributedToken = chartRound.DistributedToken,
                Total = chartRound.Total,
                Type = chartRound.Type,
                DateCreated = chartRound.DateCreated,
                DateUpdated = chartRound.DateUpdated
            };
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
