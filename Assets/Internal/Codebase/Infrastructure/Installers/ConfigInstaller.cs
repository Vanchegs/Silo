using Internal.Codebase;
using UnityEngine;
using Zenject;

public class ConfigInstaller : MonoInstaller
{
    [SerializeField] private EnemyConfig mutantConfig;

    public override void InstallBindings()
    {
        Container.Bind<EnemyConfig>()
            .FromInstance(mutantConfig)
            .WhenInjectedInto<EnemyFactory>();
    }
}
