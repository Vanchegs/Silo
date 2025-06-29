namespace Internal.Codebase.PeopleLogic
{
    public class PeopleService : IPeopleManager
    {
        private People people;
        
        public void LoadPeople()
        {
            people = new People(10);
        }

        public void ChangePeopleAmount(int changeAmount)
        {
            throw new System.NotImplementedException();
        }

        public void UpPeopleLevel()
        {
            throw new System.NotImplementedException();
        }

        public int GetPeopleAmount()
        {
            throw new System.NotImplementedException();
        }
    }
}