public class People
{
    public int Level { get; private set; }
    public int PeopleAmount { get; private set; }
    public float Speed => Level * 0.5f;

    public People(int peopleAmount) => 
        PeopleAmount = peopleAmount;

    public void LevelUp() => 
        Level ++;

    public void ChangePeopleAmount(int changeValue)
    {
        if (PeopleAmount - changeValue <= 0)
            return;
        
        PeopleAmount += changeValue;
    }
}
