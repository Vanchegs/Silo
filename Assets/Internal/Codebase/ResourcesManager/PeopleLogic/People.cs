[System.Serializable]
public class People
{
    public int Level { get; private set; }
    public int Amount { get; private set; }
    public float Speed => Level * 0.5f;

    public People(int peopleAmount) => 
        Amount = peopleAmount;

    public void LevelUp() => 
        Level ++;

    public void ChangePeopleAmount(int changeValue)
    {
        if (Amount - changeValue <= 0)
            return;
        
        Amount += changeValue;
    }

    public void ChangePeopleLevel(int level)
    {
        if (level > 0) 
            Level = level;
    }
}
