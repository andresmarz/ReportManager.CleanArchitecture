using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportManager.Application.DTOs;
using ReportManager.Application.Interfaces;
using ReportManager.Domain.Entities;
using ReportManager.Domain.Interfaces;

namespace ReportManager.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;
        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReportDto>> GetReportsAsync()
        {
            var reports = await _repository.GetAllAsync();
            return reports.Select(r => new ReportDto
            {
                Title = r.Title,
                Amount = r.Amount,
                Date = r.Date

            });
        }

        public async Task<ReportDto?> GetReportByIdAsync(int id)
        {
            var report = await _repository.GetByIdAsync(id);
            if (report == null) return null;

            return new ReportDto
            {
                Title = report.Title,
                Amount = report.Amount,
                Date = report.Date
            };
        }
        public async Task<int> CreateReportAsync(CreateReportDto dto)
        {
            var report = new Report
            {
                Title = dto.Title,
                Amount = dto.Amount,
                Date = dto.Date
            };

            await _repository.AddAsync(report);
            return report.Id;
        }

        public async Task UpdateReportAsync(int id, CreateReportDto dto)
        {
            var report = await _repository.GetByIdAsync(id);
            if (report == null) return;

            report.Title = dto.Title;
            report.Amount = dto.Amount;
            report.Date = dto.Date;
            await _repository.UpdateAsync(report);
        }
        public async Task DeleteReportAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }                    
       
    }
}
