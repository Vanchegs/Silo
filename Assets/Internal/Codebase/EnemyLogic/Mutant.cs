using UnityEngine;

namespace Internal.Codebase
{
    public class Mutant : Enemy
    {
        [SerializeField] private ParticleSystem particleSystem;
        [SerializeField] private int enemyPrice;
        
        private Vector2 direction;
        
        private void FixedUpdate() => 
            movement.Move();

        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            
            if (currentHealth < 1)
            {
                particleSystem.gameObject.SetActive(true);
                particleSystem.Play();
            }
        }

        public override void Die()
        {
            base.Die();
            EconomyController.OnUpdateCurrency.Invoke(enemyPrice);
        }
    }
}