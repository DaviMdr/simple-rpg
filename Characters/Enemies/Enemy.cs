using RPG_Simplificado.Characters;

namespace RPG_Simplificado.Characters.Enemies;

public abstract class Enemy : Character
{
    public int ExperienceReward { get; set; }
    public decimal GoldReward { get; set; }

    protected Enemy(
        string name,
        int hp,
        int attack,
        int defense,
        int experienceReward,
        decimal goldReward)
        : base(name, hp, attack, defense)
    {
        ExperienceReward = experienceReward;
        GoldReward = goldReward;
    }
}