namespace Internal.Codebase.PeopleLogic
{
    public class PeopleManager
    {
        private People people;
        
        public void LoadPeople()
        {
            people = new People(10);
        }

        public void ChangePeopleAmount(int amountChange) => 
            people.ChangePeopleAmount(amountChange);

        public void UpPeopleLevel() => 
            people.LevelUp();

        public int GetPeopleAmount() => 
            people.Amount;
    }
}