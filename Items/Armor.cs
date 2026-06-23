namespace RPG_Simplificado.Items;

public class Armor : Item
{
    public int DefenseBonus { get; set; }

    public Armor(
        string name,
        string description,
        decimal price,
        int defenseBonus)
        : base(name, description, price)
    {
        DefenseBonus = defenseBonus;
    }
}