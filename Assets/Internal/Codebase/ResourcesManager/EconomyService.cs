using Internal.Codebase.PeopleLogic;

namespace Internal.Codebase
{
    public class EconomyService : IService
    {
        private PeopleController peopleController;
        private CurrencyController currencyController;

        public PeopleController PeopleController { get; private set; }
        public CurrencyController CurrencyController { get; private set; }
        
        public EconomyService()
        {
            peopleController = new PeopleController();
            currencyController = new CurrencyController();

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