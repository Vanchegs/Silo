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
        if (enemyFactory == null)
        {
            Debug.LogError("EnemyPool не настроен правильно!");
            return null;
        }

        // Создаём врага через фабрику
        Enemy enemy = enemyFactory.CreateEnemy(enemyPoolType);
        
        if (enemy == null)
        {
            Debug.LogError($"Не удалось создать врага типа {enemyPoolType}");
            return null;
        }

        // Спавним и настраиваем врага
        Enemy spawnedEnemy = Instantiate(enemy, storagePoint);
        spawnedEnemy.gameObject.SetActive(false);
        enemies.Add(spawnedEnemy);
        
        return spawnedEnemy;
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
