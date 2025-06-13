using Zenject;

namespace Internal.Codebase.Infrastructure.Installers
{
    public class FactoryInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IEnemyFactory>()
                .To<EnemyFactory>()
                .AsCached();
        }
    }
}