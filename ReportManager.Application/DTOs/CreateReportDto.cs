namespace ReportManager.Application.DTOs
{
    public class CreateReportDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
