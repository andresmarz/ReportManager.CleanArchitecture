using ReportManager.Application.DTOs;

namespace ReportManager.Application.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ReportDto>> GetReportsAsync();
        Task<ReportDto?> GetReportByIdAsync(int id);
        Task<int> CreateReportAsync(CreateReportDto dto);
        Task UpdateReportAsync(int id, CreateReportDto dto);
        Task DeleteReportAsync(int id);
    }
}
