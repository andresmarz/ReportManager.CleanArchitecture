using Microsoft.AspNetCore.Mvc;
using ReportManager.Application.DTOs;
using ReportManager.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateReport(CreateReportDto dto)
    {
        await _reportService.AddReportAsync(dto);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetReports()
    {
        var reports = await _reportService.GetReportsAsync();
        return Ok(reports);
    }
}
