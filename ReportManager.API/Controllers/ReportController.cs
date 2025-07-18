using Microsoft.AspNetCore.Mvc;
using ReportManager.Application.DTOs;
using ReportManager.Application.Interfaces;

namespace ReportManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    //GET: api/Report
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reports = await _reportService.GetReportsAsync();
        return Ok(reports);
    }


    //GET: api/report/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var report = await _reportService.GetReportByIdAsync(id);
        if (report == null) return NotFound();
        return Ok(report);
    }


    [HttpPost]
    public async Task<IActionResult> CreateReport(CreateReportDto dto)
    {
        await _reportService.CreateReportAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.Title }, dto);
    }

    
}
