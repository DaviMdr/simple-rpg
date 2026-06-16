namespace RPG_Simplificado.Characters.Heroes;

public class Warrior : Heroe
{
    public Warrior(string name)
        : base(name, 120, 20, 10)
    {
    }

    public override int SpecialAttack()
    {
        return Attack * 2;
    }
}