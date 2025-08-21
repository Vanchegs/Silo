using UnityEngine;

namespace Internal.Codebase
{
    [CreateAssetMenu(menuName = "Configs/EnemyConfig", fileName = "EnemyConfig", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        public EnemySettings EnemySettings;
        public Enemy EnemyPrefab;
    }
}

