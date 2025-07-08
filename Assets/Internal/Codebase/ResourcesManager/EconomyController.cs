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

            economyView = FindView();
            UpdateUI();
        }

        private void UpdateUI()
        {
            var peopleAmount = economyService.PeopleController.GetPeople().Amount;
            var currency = economyService.CurrencyController.GetCurrencyAmount();
            
            economyView.UpdateEconomyDisplay(peopleAmount, currency);
        }

        private EconomyView FindView()
        {
            var view = FindObjectOfType<EconomyView>();
            return view;
        }
    }
}