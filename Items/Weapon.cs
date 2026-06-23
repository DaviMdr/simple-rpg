namespace RPG_Simplificado.Items;

public class Weapon : Item
{
    public int AttackBonus { get; set; }

    public Weapon(
        string name,
        string description,
        decimal price,
        int attackBonus)
        : base(name, description, price)
    {
        AttackBonus = attackBonus;
    }
}