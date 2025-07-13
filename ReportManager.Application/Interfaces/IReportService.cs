using ReportManager.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Application.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ReportDto>> GetReportsAsync();
        Task<ReportDto?> GetReportByIdAsync(int id);
        Task CreateReportAsync(ReportDto report);
        Task UpdateReportAsync(int id, ReportDto report);
        Task DeleteReportAsync(int id);

    }
}
