namespace Internal.Codebase
{
    public class PeopleModel
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

        public People GetPeople() => 
            people;
        
        public void LoadSaveData(SaveData saveData)
        {
            people.ChangePeopleAmount(saveData.people.Amount);
            people.ChangePeopleLevel(saveData.people.Level);
        }
    }
}