namespace RPG_Simplificado.Characters.Heroes;

public class Wizard : Heroe
{
    public Wizard(string name)
        : base(name, 80, 25, 4)
    {
    }

    public override int SpecialAttack()
    {
        return Attack + 20;
    }
}