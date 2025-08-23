namespace EcoDrop.Domain.Entities;

public class RecyclingPoint
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    
    public ICollection<RecyclingPointMaterialType> Materials { get; set; } = new List<RecyclingPointMaterialType>();

    
    public ICollection<OpeningHour> OpeningHours { get; set; } = new List<OpeningHour>();
}
