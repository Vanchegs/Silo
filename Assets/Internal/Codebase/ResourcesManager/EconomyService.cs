using System;

namespace Internal.Codebase
{
    public class EconomyService : IService
    {
        private PeopleModel peopleModel;
        private CurrencyModel currencyModel;

        public static Action<int, int> OnUpdateEconomyDisplay;

        public PeopleModel PeopleController { get; private set; }
        public CurrencyModel CurrencyController { get; private set; }
        public TransitionalData TransitionalData { get; private set; }
        
        public EconomyService()
        {
            peopleModel = new PeopleModel();
            currencyModel = new CurrencyModel();

            CurrencyController = currencyModel;
            PeopleController = peopleModel;
            TransitionalData = new TransitionalData(peopleModel.GetPeople(), currencyModel.GetCurrencyAmount());
        }

        public void LoadSavedData(SaveData saveData)
        {
            peopleModel.LoadSaveData(saveData);
            currencyModel.LoadSaveData(saveData);
        }
    }
}