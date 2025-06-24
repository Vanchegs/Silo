using UnityEngine;

namespace Internal.Codebase
{
    public class Enemy : MonoBehaviour
    {
        private int speed;
        private int damage;
        private bool isDead;
        private float currentHealth;
        private int maxHealth;

        internal IMovement movement;

        private void FixedUpdate() => 
            movement.Move();

        public void Initialize(EnemyConfig enemyConfig, Transform shelterPosition)
        {
            speed = enemyConfig.speed;
            damage = enemyConfig.damage;
            maxHealth = enemyConfig.maxHealth;
            movement = new MutantMovement(transform, shelterPosition, enemyConfig);
            
            currentHealth = maxHealth;
            
            Debug.Log("Инициализация");
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

        private void Die() => 
            Destroy(gameObject);
    }
}
