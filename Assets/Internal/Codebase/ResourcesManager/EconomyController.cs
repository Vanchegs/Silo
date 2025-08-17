using System;
using UnityEngine;

namespace Internal.Codebase
{
    public class EconomyController : MonoBehaviour
    {
        private EconomyDataService economyService;
        private EconomyView economyView;

        public static Action OnUpdateEconomyUI;
        public static Action<int> OnUpdateCurrency;
        
        private void Start()
        {
            OnUpdateEconomyUI += UpdateEconomyUI;
            OnUpdateCurrency += AccrualMoney;
            
            economyService = (EconomyDataService)ServiceLocator.GetService<EconomyDataService>();
            
            UpdateEconomyUI();
        }

        private void OnDisable()
        {
            OnUpdateEconomyUI -= UpdateEconomyUI;
            OnUpdateCurrency += AccrualMoney;
        }

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

        private void AccrualMoney(int accrualAmount)
        {
            if (economyService?.CurrencyModel == null)
            {
                Debug.LogError("CurrencyModel is null!");
                return;
            }
            
            economyService.CurrencyModel.TryChangeCurrencyAmount(accrualAmount);
            OnUpdateEconomyUI?.Invoke();
        }
    }
}