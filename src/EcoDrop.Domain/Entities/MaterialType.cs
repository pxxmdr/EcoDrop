namespace EcoDrop.Domain.Entities;

public class MaterialType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<RecyclingPointMaterialType> RecyclingPoints { get; set; } = new List<RecyclingPointMaterialType>();
}
