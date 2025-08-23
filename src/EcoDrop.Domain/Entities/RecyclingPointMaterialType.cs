namespace EcoDrop.Domain.Entities;

public class RecyclingPointMaterialType
{
    public int RecyclingPointId { get; set; }
    public RecyclingPoint? RecyclingPoint { get; set; }

    public int MaterialTypeId { get; set; }
    public MaterialType? MaterialType { get; set; }
}
