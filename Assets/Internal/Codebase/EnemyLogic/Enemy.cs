using UnityEngine;

namespace Internal.Codebase
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyStats enemyStats;
        
        private int damage;
        private bool isDead;

        internal float currentHealth;
        
        internal IMovement movement;

        public void Initialize()
        {
            damage = enemyStats.Damage;
            
            movement = new MutantMovement(transform, enemyStats.Speed);
            currentHealth = enemyStats.MaxHealth;
        }

        public virtual void TakeDamage(float damage)
        {
            if (isDead) 
                return;

            if (currentHealth <= 0)
            {
                isDead = true;
                Die();
            }
            
            currentHealth -= damage;
        }

        public void SetPosition(Vector2 position) => 
            transform.position = position;

        public virtual void Die() => 
            gameObject.SetActive(false);
    }
}
