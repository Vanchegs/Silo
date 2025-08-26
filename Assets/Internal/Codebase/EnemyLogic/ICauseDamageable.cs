namespace Internal.Codebase
{
    public interface ICauseDamageable
    {
        public void CauseDamage(ITakeDamageable takeDamageable, float damage);
    }
}