using RPG_Simplificado.Characters.Enemies;

namespace RPG_Simplificado.Systems.Game;

public static class EnemyFactory
{
    public static Enemy CreateRandomEnemy()
    {
        Random random = new();

        switch (random.Next(3))
        {
            case 0:
                return new Goblin();

            case 1:
                return new Orc();

            default:
                return new Dragon();
        }
    }
}