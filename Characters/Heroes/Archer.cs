namespace RPG_Simplificado.Characters.Heroes;

public class Archer : Heroe
{
    public Archer(string name)
        : base(name, 90, 18, 6)
    {
    }

    public override int SpecialAttack()
    {
        return Attack + 10;
    }
}