using UnityEngine;

namespace Internal.Codebase
{
    [CreateAssetMenu(menuName = "Configs/EnemyConfig", fileName = "EnemyConfig", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        public int Speed;
        public int Damage;
        public int MaxHealth;
        public Enemy EnemyPrefab;
    }
}

