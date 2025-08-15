using Internal.Codebase;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private EnemyType enemyPoolType;
    [SerializeField] private Transform storagePoint;
    [SerializeField] private EnemyConfigsDictionary enemyConfigs;
    
    private List<Enemy> enemies;
    private EnemyFactory enemyFactory;

    public void Awake()
    {
        enemies = new List<Enemy>();
        enemyFactory = new EnemyFactory(enemyConfigs);
    }

    public void InitPool(int poolSize)
    {
        for (int i = 0; i < poolSize; i++) 
            CreateNewEnemy();
    }

    public Enemy CreateNewEnemy()
    {
        Enemy newEnemy = enemyFactory.CreateEnemy(enemyPoolType);
        
        newEnemy.transform.SetParent(storagePoint);
        newEnemy.gameObject.SetActive(false);
        
        enemies.Add(newEnemy);
        
        return newEnemy;
    }
    
    public void ReturnEnemy(Enemy enemy) => 
        enemy.gameObject.SetActive(false);

    public Enemy GetEnemy()
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null && !enemy.gameObject.activeInHierarchy)
            {
                enemy.gameObject.SetActive(true);
                return enemy;
            }
        }
    
        return CreateNewEnemy();
    }
}
