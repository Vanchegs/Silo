using Internal.Codebase.PeopleLogic;

namespace Internal.Codebase
{
    public class EconomyController
    {
        private PeopleController peopleController;
        private CurrencyController currencyController;

        public PeopleController PeopleController { get; private set; }
        public CurrencyController CurrencyController { get; private set; }
        
        public EconomyController()
        {
            peopleController = new PeopleController();
            currencyController = new CurrencyController();

            CurrencyController = currencyController;
            PeopleController = peopleController;
        }
    }
}