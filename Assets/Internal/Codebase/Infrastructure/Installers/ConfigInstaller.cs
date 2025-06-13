using AYellowpaper.SerializedCollections;
using Internal.Codebase;
using UnityEngine;
using Zenject;

public class ConfigInstaller : MonoInstaller
{
    [SerializeField] private SerializedDictionary<EnemyType, EnemyConfig> enemyConfigs;

    public override void InstallBindings()
    {
        Container.Bind<SerializedDictionary<EnemyType, EnemyConfig>>()
            .FromInstance(enemyConfigs)
            .AsSingle();
    }
}
