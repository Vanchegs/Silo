using System;
using UnityEngine;

namespace Internal.Codebase
{
    public class EconomyController : MonoBehaviour
    {
        private EconomyDataService economyService;
        private EconomyView economyView;

        public static Action OnUpdateEconomyUI;
        
        private void Start()
        {
            OnUpdateEconomyUI += UpdateEconomyUI;
            
            economyService = (EconomyDataService)ServiceLocator.GetService<EconomyDataService>();
            
            UpdateEconomyUI();
        }

        private void OnDisable() => 
            OnUpdateEconomyUI -= UpdateEconomyUI;

        private void UpdateEconomyUI()
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