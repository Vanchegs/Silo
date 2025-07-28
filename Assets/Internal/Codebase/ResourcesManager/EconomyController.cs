using UnityEngine;

namespace Internal.Codebase
{
    public class EconomyController : MonoBehaviour
    {
        private EconomyService economyService;
        private EconomyView economyView;
        
        private void Start()
        {
            economyService = (EconomyService)ServiceLocator.GetService<EconomyService>();
            
            UpdateUI();
        }

        private void UpdateUI()
        {
            economyView = FindView();
            
            var peopleAmount = economyService.PeopleModel.GetPeople().Amount;
            var currency = economyService.CurrencyModel.GetCurrencyAmount();
            
            economyView.UpdateEconomyDisplay(peopleAmount, currency);
        }

        private EconomyView FindView()
        {
            var view = FindObjectOfType<EconomyView>();
            return view;
        }
    }
}