using RPG_Simplificado.Characters.Heroes;
using RPG_Simplificado.Interfaces;

namespace RPG_Simplificado.Items;

public class Potion : IUsable
{
    public string Name { get; set; }
    public int HealAmount { get; set; }

    public Potion()
    {
        Name = "Poção Simples";
        HealAmount = 20;
    }

    public Potion(string name, int healAmount)
    {
        Name = name;
        HealAmount = healAmount;
    }

    public void Use(Heroe hero)
    {
        hero.HP += HealAmount;
    }
}