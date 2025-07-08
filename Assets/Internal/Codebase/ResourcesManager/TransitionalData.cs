namespace Internal.Codebase
{
    public class TransitionalData
    {
        private People people;
        private int currency;
        
        public People People 
        { 
            get => people;
            set => people = value != null && value.Amount > 0 ? value : people; 
        }

        public int Currency
        {
            get => currency;
            set => currency = value != null && currency >= 0 ? value : 0;
        }

        public TransitionalData(People people, int currency)
        {
            People = people;
            Currency = currency;
        }
    }
}

