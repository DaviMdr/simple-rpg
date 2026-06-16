namespace RPG_Simplificado.Characters;

public abstract class Character
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    protected Character(
        string name,
        int hp,
        int attack,
        int defense)
    {
        Name = name;
        HP = hp;
        Attack = attack;
        Defense = defense;
    }

    public bool IsAlive()
    {
        return HP > 0;
    }

    public void TakeDamage(int damage)
    {
        int finalDamage = Math.Max(1, damage - Defense);

        HP -= finalDamage;

        if (HP < 0)
        {
            HP = 0;
        }
    }
}