using Internal.Codebase;
using System.Collections.Generic;

public class EnemyPool
{
    private List<Enemy> enemies;
    private EnemyFactory enemyFactory;
    private EnemyType enemyPoolType;
    
    public EnemyPool(EnemyType enemyType, EnemyConfigsDictionary enemyConfigs)
    {
        enemies = new List<Enemy>();
        enemyFactory = new EnemyFactory(enemyConfigs);
        enemyPoolType = enemyType;
    }

    public void InitPool(int poolSize, EnemyType enemyType)
    {
        for (int i = 0; i < poolSize; i++) 
            CreateNewEnemy();
    }

    public void CreateNewEnemy() => 
        enemies.Add(enemyFactory.CreateEnemy(enemyPoolType));

    public Enemy TryGetEnemy(Enemy enemy)
    {
        return null;
    }
}
