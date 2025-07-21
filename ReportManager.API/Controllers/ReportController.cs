using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportManager.Application.DTOs;
using ReportManager.Application.Interfaces;

namespace ReportManager.API.Controllers;

[Authorize]
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

    //POST: api/Report
    [HttpPost]
    public async Task<IActionResult> CreateReport(CreateReportDto dto)
    {
        int id = await _reportService.CreateReportAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = id }, dto);
    }

    //PUT: api/Report/5
    [HttpPut]
    public async Task<IActionResult> UpdateReport(int id, CreateReportDto dto)
    {
        await _reportService.UpdateReportAsync(id, dto);
        return NoContent();
    }

    //DELETE: api/Report/5
    [HttpDelete]
    public async Task<IActionResult> DeleteReport(int id)
    {
        await _reportService.DeleteReportAsync(id);
        return NoContent();
    }
}
