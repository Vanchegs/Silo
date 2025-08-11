using Internal.Codebase;
using System.Collections.Generic;

public class EnemyPool<T> where T : Enemy
{
    private List<T> enemies;
    private EnemyFactory enemyFactory;
    
    public EnemyPool(EnemyConfigsDictionary enemyConfigs)
    {
        enemies = new List<T>();
        enemyFactory = new EnemyFactory(enemyConfigs);
    }

    public void InitPool(int poolSize, EnemyType enemyType)
    {
        for (int i = 0; i < poolSize; i++)
        {
            CreateNewEnemy(enemyFactory.CreateEnemy(enemyType));
        }
    }

    public void CreateNewEnemy<T>(T enemy) where T : Enemy
    {
        
    }

    public T TryGetEnemy(T enemy)
    {
        
    }
}
