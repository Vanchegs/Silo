using System;
using UnityEngine;

namespace Internal.Codebase
{
    public class Enemy : MonoBehaviour, ITakeDamageable, ICauseDamageable
    {
        [SerializeField] private EnemyStats enemyStats;
        
        private float damage;
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

        public virtual void Die()
        {
            gameObject.SetActive(false);
            ResetStats();
        }

        private void ResetStats()
        {
            currentHealth = enemyStats.MaxHealth;
            isDead = false;
        }

        public void CauseDamage(ITakeDamageable takeDamageable, float damage) => 
            takeDamageable.TakeDamage(damage);

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.tag == "Wall")
            {
                var target = other.gameObject.GetComponent<ITakeDamageable>();
                CauseDamage(target, damage);
                Debug.Log("Wall take damage");
            }
        }
    }
}
