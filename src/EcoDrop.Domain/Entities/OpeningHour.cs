namespace EcoDrop.Domain.Entities;

public class OpeningHour
{
    public int Id { get; set; }
    public int RecyclingPointId { get; set; }
    public RecyclingPoint? RecyclingPoint { get; set; }

    public string DayOfWeek { get; set; } = string.Empty;
    public string OpenTime { get; set; } = string.Empty;
    public string CloseTime { get; set; } = string.Empty;
}
