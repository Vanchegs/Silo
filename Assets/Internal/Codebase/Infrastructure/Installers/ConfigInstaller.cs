using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Internal.Codebase;
using UnityEngine;
using Zenject;

public class ConfigInstaller : MonoInstaller
{
    [SerializeField] private SerializedDictionary<EnemyType, EnemyConfig> enemyConfigs;

    public override void InstallBindings()
    {
        Container.Bind<Dictionary<EnemyType, EnemyConfig>>()
            .FromInstance(new Dictionary<EnemyType, EnemyConfig>(enemyConfigs))
            .AsSingle();
    }
}
