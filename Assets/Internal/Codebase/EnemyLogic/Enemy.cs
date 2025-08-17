using UnityEngine;

namespace Internal.Codebase
{
    public class Enemy : MonoBehaviour
    {
        private int damage;
        private bool isDead;
        private int maxHealth;

        internal float currentHealth;
        
        internal IMovement movement;

        public void Initialize(EnemyConfig enemyConfig)
        {
            damage = enemyConfig.Damage;
            maxHealth = enemyConfig.MaxHealth;
            
            movement = new MutantMovement(transform, enemyConfig);
            currentHealth = maxHealth;
        }

        public virtual void TakeDamage(float damage)
        {
            if (isDead) return;
            
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                isDead = true;
                Die();
            }
        }

        public void SetPosition(Vector2 position) => 
            transform.position = position;

        public virtual void Die() => 
            gameObject.SetActive(false);
    }
}
