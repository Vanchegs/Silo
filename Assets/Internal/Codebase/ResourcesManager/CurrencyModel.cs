namespace Internal.Codebase
{
    public class CurrencyModel
    {
        private int currency;
        
        public void LoadCurrency() => 
            currency = 10;

        public void ChangeCurrencyAmount(int changeValue)
        {
            if (currency + changeValue < 0)
                return;
        
            currency += changeValue;
        }
        
        public bool TryChangeCurrencyAmount(int changeValue)
        {
            if (currency + changeValue < 0)
                 return false;
        
            currency += changeValue;
            return true;
        }

        public int GetCurrencyAmount() => 
            currency;

        public void LoadSaveData(SaveData saveData)
        {
            if (saveData.currency > 0) 
                currency = saveData.currency;
        }
    }
}