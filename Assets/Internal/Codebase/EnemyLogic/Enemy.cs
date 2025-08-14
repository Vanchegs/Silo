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

        public void Initialize(EnemyConfig enemyConfig)
        {
            speed = enemyConfig.Speed;
            damage = enemyConfig.Damage;
            maxHealth = enemyConfig.MaxHealth;
            
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
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

        public void Die() => 
            gameObject.SetActive(false);
    }
}
