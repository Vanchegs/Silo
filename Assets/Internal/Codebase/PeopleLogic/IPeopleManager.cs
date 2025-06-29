namespace Internal.Codebase.PeopleLogic
{
    public interface IPeopleManager
    {
        public void LoadPeople();
        public void ChangePeopleAmount(int changeAmount);
        public void UpPeopleLevel();
        public int GetPeopleAmount();
    }
}