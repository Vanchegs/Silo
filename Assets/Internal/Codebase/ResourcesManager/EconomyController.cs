using UnityEngine;

namespace Internal.Codebase
{
    public class EconomyController : MonoBehaviour
    {
        private EconomyService economyService;
        
        private void Start()
        {
            economyService = (EconomyService)ServiceLocator.GetService<EconomyService>();
        }
    }
}