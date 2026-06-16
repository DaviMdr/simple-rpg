using RPG_Simplificado.Characters;

namespace RPG_Simplificado.Characters.Enemies;

public abstract class Enemy : Character
{
    public int ExperienceReward { get; set; }

    protected Enemy(
        string name,
        int hp,
        int attack,
        int defense,
        int experienceReward)
        : base(name, hp, attack, defense)
    {
        ExperienceReward = experienceReward;
    }
}