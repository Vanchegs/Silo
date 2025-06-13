using UnityEngine;
using Zenject;

namespace Internal.Codebase
{
    public class EnemySpawner : MonoBehaviour
    {
        private IEnemyFactory mutantFactory;
        
        private void Start()
        {
            SpawnMutant();
        }

        [Inject]
        public void Construct(IEnemyFactory mutantFactory) => 
            this.mutantFactory = mutantFactory;

        public void SpawnMutant()
        {
            Camera mainCamera = Camera.main;
            
            float cameraHeight = 2f * mainCamera.orthographicSize;
            float cameraWidth = cameraHeight * mainCamera.aspect;
    
            float spawnMargin = 2f;
    
            int spawnSide = Random.Range(0, 4);
    
            Vector2 spawnPos = Vector2.zero;
    
            switch(spawnSide)
            {
                case 0:
                    spawnPos = new Vector2(
                        Random.Range(-cameraWidth/2 - spawnMargin, cameraWidth/2 + spawnMargin),
                        mainCamera.transform.position.y + cameraHeight/2 + spawnMargin
                    );
                    break;
                case 1:
                    spawnPos = new Vector2(
                        mainCamera.transform.position.x + cameraWidth/2 + spawnMargin,
                        Random.Range(-cameraHeight/2 - spawnMargin, cameraHeight/2 + spawnMargin)
                    );
                    break;
                case 2:
                    spawnPos = new Vector2(
                        Random.Range(-cameraWidth/2 - spawnMargin, cameraWidth/2 + spawnMargin),
                        mainCamera.transform.position.y - cameraHeight/2 - spawnMargin
                    );
                    break;
                case 3:
                    spawnPos = new Vector2(
                        mainCamera.transform.position.x - cameraWidth/2 - spawnMargin,
                        Random.Range(-cameraHeight/2 - spawnMargin, cameraHeight/2 + spawnMargin)
                    );
                    break;
            }
    
            Instantiate(mutantFactory.CreateEnemy(), spawnPos, Quaternion.identity);
        }
    }
}