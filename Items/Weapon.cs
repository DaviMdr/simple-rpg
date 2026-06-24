using RPG_Simplificado.Characters.Heroes;
using RPG_Simplificado.Interfaces;

namespace RPG_Simplificado.Items;

public class Weapon : Item, IEquippable
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

    public void Equip(Heroe heroe)
    {
        heroe.EquippedWeapon = this;
        Console.WriteLine(
            $"{heroe.Name} equipou {Name} (+{AttackBonus} ATK)"
        );
    }
}