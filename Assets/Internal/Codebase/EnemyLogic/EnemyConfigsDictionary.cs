using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Internal.Codebase
{
    [CreateAssetMenu(menuName = "Configs/EnemyDictionary", fileName = "EnemyDictionary", order = 0)]
    public class EnemyConfigsDictionary : ScriptableObject
    {
        [SerializedDictionary] public SerializedDictionary<EnemyType, EnemyConfig> configs;
    }
}