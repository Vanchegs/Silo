using Internal.Codebase;
using UnityEngine;

public class ShelterWall : MonoBehaviour, ITakeDamageable
{
    public float Health { get; private set; }
    
    public void TakeDamage(float damage)
    {
        
    }
}
