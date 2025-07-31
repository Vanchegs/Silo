using UnityEngine;

namespace Internal.Codebase
{
    public class Store : MonoBehaviour
    {
        private EconomyDataService economyDataService;
      
        private void Start()
        {
            economyDataService = (EconomyDataService)ServiceLocator.GetService<EconomyDataService>(); 
        }

        public void RecruitPeople()
        {
            if (economyDataService.CurrencyModel.TryChangeCurrencyAmount(-5))
                economyDataService.PeopleModel.ChangePeopleAmount(10);
            else
                Debug.Log("Недостаточно денег");
            
            EconomyController.OnUpdateEconomyUI.Invoke();
        }
    }  
}


