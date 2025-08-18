using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            OnUpdateCurrency += AccrualBalance;
            
            economyService = (EconomyDataService)ServiceLocator.GetService<EconomyDataService>();
            OnUpdateCurrency.Invoke(10);
            Debug.Log(SceneManager.loadedSceneCount);
            
            UpdateEconomyUI();
        }

        private void OnDisable()
        {
            OnUpdateEconomyUI -= UpdateEconomyUI;
            OnUpdateCurrency += AccrualBalance;
        }

        private void UpdateEconomyUI()
        {
            economyView = FindView();
            
            var peopleAmount = economyService.PeopleModel.GetPeople().Amount;
            var currency = economyService.CurrencyModel.GetCurrencyAmount();
            
            Debug.Log(economyService);
            
            economyView.UpdateEconomyDisplay(peopleAmount, currency);
        }

        private EconomyView FindView()
        {
            var view = FindObjectOfType<EconomyView>();
            return view;
        }

        private void AccrualBalance(int accrualAmount)
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