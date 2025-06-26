using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Internal.Codebase
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform shelterPosition;
        [SerializeField] private int minSpawnTime, maxSpawnTime;
        
        private IEnemyFactory enemyFactory;
        private Camera mainCamera;
        private float cameraHeight;
        private float cameraWidth;
        private float spawnMargin;
     
        [Inject] private readonly Dictionary<EnemyType, EnemyConfig> enemyConfigs;
        
        private void Start()
        {
            mainCamera = CameraCash(out cameraHeight, out cameraWidth, out spawnMargin);
            
            SpawnEnemy(EnemyType.Mutant);

            StartCoroutine(RegularSpawnMutant());
        }

        [Inject]
        public void Construct(IEnemyFactory enemyFactory) => 
            this.enemyFactory = enemyFactory;

        public void SpawnEnemy(EnemyType enemyType)
        {
            var spawnPos = SpawnPosDefinition();

            var enemy = Instantiate(enemyFactory.CreateEnemy(enemyType), spawnPos, Quaternion.identity);
            enemy.Initialize(enemyConfigs[enemyType], shelterPosition);
        }

        private Vector2 SpawnPosDefinition()
        {
            int spawnSide = Random.Range(0, 4);

            Vector2 spawnPos = Vector2.zero;

            switch (spawnSide)
            {
                case 0:
                    spawnPos = new Vector2(
                        Random.Range(-cameraWidth / 2 - spawnMargin, cameraWidth / 2 + spawnMargin),
                        mainCamera.transform.position.y + cameraHeight / 2 + spawnMargin
                    );
                    break;
                case 1:
                    spawnPos = new Vector2(
                        mainCamera.transform.position.x + cameraWidth / 2 + spawnMargin,
                        Random.Range(-cameraHeight / 2 - spawnMargin, cameraHeight / 2 + spawnMargin)
                    );
                    break;
                case 2:
                    spawnPos = new Vector2(
                        Random.Range(-cameraWidth / 2 - spawnMargin, cameraWidth / 2 + spawnMargin),
                        mainCamera.transform.position.y - cameraHeight / 2 - spawnMargin
                    );
                    break;
                case 3:
                    spawnPos = new Vector2(
                        mainCamera.transform.position.x - cameraWidth / 2 - spawnMargin,
                        Random.Range(-cameraHeight / 2 - spawnMargin, cameraHeight / 2 + spawnMargin)
                    );
                    break;
            }

            return spawnPos;
        }

        private static Camera CameraCash(out float cameraHeight, out float cameraWidth, out float spawnMargin)
        {
            Camera mainCamera = Camera.main;

            cameraHeight = 2f * mainCamera.orthographicSize;
            cameraWidth = cameraHeight * mainCamera.aspect;

            spawnMargin = 2f;
            return mainCamera;
        }

        private IEnumerator RegularSpawnMutant()
        {
            while (true)
            {
                var waitingTime = Random.Range(minSpawnTime, maxSpawnTime);
                
                SpawnEnemy(EnemyType.Mutant);
                
                yield return new WaitForSeconds(waitingTime); 
            }
        }
    }
}