using System;

namespace Internal.Codebase
{
    public class EconomyService : IService
    {
        private PeopleModel peopleController;
        private CurrencyModel currencyController;

        public static Action<int, int> OnUpdateEconomyDisplay;

        public PeopleModel PeopleController { get; private set; }
        public CurrencyModel CurrencyController { get; private set; }
        
        public EconomyService()
        {
            peopleController = new PeopleModel();
            currencyController = new CurrencyModel();

            CurrencyController = currencyController;
            PeopleController = peopleController;
        }

        public void LoadData(SaveData saveData)
        {
            peopleController.LoadSaveData(saveData);
            currencyController.LoadSaveData(saveData);
        }
    }
}