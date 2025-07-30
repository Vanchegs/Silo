using System;

namespace Internal.Codebase
{
    public class EconomyDataService : IService
    {
        private PeopleModel peopleModel;
        private CurrencyModel currencyModel;

        public static Action<int, int> OnUpdateEconomyDisplay;

        public PeopleModel PeopleModel { get => peopleModel; private set => peopleModel = value; }
        public CurrencyModel CurrencyModel { get => currencyModel; private set => currencyModel = value; }
        public TransitionalData TransitionalData { get; private set; }
        
        public EconomyDataService()
        {
            peopleModel = new PeopleModel();
            currencyModel = new CurrencyModel();
            currencyModel.LoadCurrency();
            peopleModel.LoadPeople();

            TransitionalData = new TransitionalData(peopleModel.GetPeople(), currencyModel.GetCurrencyAmount());
        }

        public void LoadSavedData(SaveData saveData)
        {
            peopleModel.LoadSaveData(saveData);
            currencyModel.LoadSaveData(saveData);
        }
    }
}