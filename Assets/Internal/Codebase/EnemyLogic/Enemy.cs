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

        public void Initialize(EnemySettings enemySettings)
        {
            damage = enemySettings.Damage;
            maxHealth = enemySettings.MaxHealth;
            
            movement = new MutantMovement(transform, enemySettings.Speed);
            currentHealth = maxHealth;
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
