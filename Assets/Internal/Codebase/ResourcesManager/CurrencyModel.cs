namespace Internal.Codebase
{
    public class CurrencyModel
    {
        private int currency;
        
        public void LoadPeople()
        {
            currency = 10;
        }

        public void ChangeCurrencyAmount(int amountChange) => 
            currency += amountChange;
        
        public int GetCurrencyAmount() => 
            currency;

        public void LoadSaveData(SaveData saveData)
        {
            if (saveData.currency > 0) 
                currency = saveData.currency;
        }
    }
}