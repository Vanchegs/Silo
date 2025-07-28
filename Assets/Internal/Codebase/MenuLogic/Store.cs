using UnityEngine;

namespace Internal.Codebase
{
    public class Store : MonoBehaviour
    {
        private EconomyService economyService;
      
        private void Start()
        {
            economyService = (EconomyService)ServiceLocator.GetService<EconomyService>(); 
        }

        public void RecruitPeople()
        {
            economyService.PeopleModel.ChangePeopleAmount(10);
            economyService.CurrencyModel.ChangeCurrencyAmount(-5);
            EconomyController.OnUpdateEconomyUI.Invoke();
        }
    }  
}


