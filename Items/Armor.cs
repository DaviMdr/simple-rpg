using RPG_Simplificado.Characters.Heroes;
using RPG_Simplificado.Interfaces;

namespace RPG_Simplificado.Items;

public class Armor : Item, IEquippable
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

    public void Equip(Heroe heroe)
    {
        heroe.EquippedArmor = this;

        Console.WriteLine(
            $"{heroe.Name} equipou {Name} (+{DefenseBonus} DEF)"
        );
    }
}