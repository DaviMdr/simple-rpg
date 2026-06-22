namespace RPG_Simplificado.Items;

public abstract class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    protected Item(
        string name,
        string description,
        decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }
}