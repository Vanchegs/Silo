using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Installers
{
    public class PrefabInstaller : MonoInstaller
    {
        [SerializeField] private GameObject mutantPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<Enemy>()
                .FromComponentInNewPrefab(mutantPrefab) 
                .WhenInjectedInto<EnemyFactory>();
        }
    }
}