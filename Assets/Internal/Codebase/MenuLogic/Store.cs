using UnityEngine;

namespace Internal.Codebase
{
    public class Store : MonoBehaviour
    {
        private EconomyDataService economyService;
      
        private void Start()
        {
            economyService = (EconomyDataService)ServiceLocator.GetService<EconomyDataService>(); 
        }

        public void RecruitPeople()
        {
            economyService.PeopleModel.ChangePeopleAmount(10);
            economyService.CurrencyModel.ChangeCurrencyAmount(-5);
            EconomyController.OnUpdateEconomyUI.Invoke();
        }
    }  
}


