using RPG_Simplificado.Characters;
using RPG_Simplificado.Items;
using RPG_Simplificado.Finance;

namespace RPG_Simplificado.Characters.Heroes;

public abstract class Heroe : Character
{
    public int Level { get; set; }
    public int Experience { get; set; }

    public List<Potion> Inventory { get; }
    public Wallet Wallet { get; set; }

    protected Heroe(
        string name,
        int hp,
        int attack,
        int defense)
        : base(name, hp, attack, defense)
    {
        Level = 1;
        Experience = 0;
        Inventory = new List<Potion>();
        Wallet = new Wallet();
    }

    public abstract int SpecialAttack();

    public void GainExperience(int xp)
    {
        Experience += xp;

        if (Experience >= 100)
        {
            Level++;

            Experience = 0;

            HP += 20;
            Attack += 5;
            Defense += 2;

            Console.WriteLine(
                $"{Name} subiu para o nível {Level}!"
            );
        }
    }

    public void RestoreStats(
        int hp,
        int attack,
        int defense,
        int level,
        int experience)
    {
        HP = hp;
        Attack = attack;
        Defense = defense;
        Level = level;
        Experience = experience;
    }
}