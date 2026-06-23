using RPG_Simplificado.Characters.Heroes;
using RPG_Simplificado.Interfaces;

namespace RPG_Simplificado.Items;

public class Potion : Item, IUsable
{
    public int HealAmount { get; set; }

    public Potion()
        : base(
            "Poção Simples",
            "Recupera 20 HP",
            10)
    {
        HealAmount = 20;
    }

    public Potion(
        string name,
        string description,
        decimal price,
        int healAmount)
        : base(
            name,
            description,
            price)
    {
        HealAmount = healAmount;
    }

    public void Use(Heroe hero)
    {
        hero.HP += HealAmount;
    }
}