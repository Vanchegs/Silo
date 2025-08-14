using Internal.Codebase;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool
{
    private List<Enemy> enemies;
    private EnemyFactory enemyFactory;
    private EnemyType enemyPoolType;
    private Transform storagePoint;
    
    public EnemyPool(EnemyType enemyType, EnemyConfigsDictionary enemyConfigs)
    {
        enemies = new List<Enemy>();
        enemyFactory = new EnemyFactory(enemyConfigs);
        enemyPoolType = enemyType;
    }

    public void InitPool(int poolSize)
    {
        for (int i = 0; i < poolSize; i++) 
            CreateNewEnemy();
    }

    public Enemy CreateNewEnemy()
    {
        var enemy = enemyFactory.CreateEnemy(enemyPoolType);
        enemies.Add(enemy);
        return enemy;
    }
    
    public void ReturnEnemy(Enemy enemy) => 
        enemy.gameObject.SetActive(false);

    public Enemy GetEnemy()
    {
        foreach (var enemy in enemies)
        {
            if (!enemy.enabled)
                return enemy;
        }
        
        return CreateNewEnemy();
    }
}
