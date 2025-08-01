using UnityEngine;

namespace Internal.Codebase
{
    public class Mutant : Enemy
    {
        private Vector2 direction;
        
        private void FixedUpdate() => 
            movement.Move();

        public override void Initialize(EnemyConfig enemyConfig, Transform shelterPosition)
        {
            base.Initialize(enemyConfig, shelterPosition);
            movement = new MutantMovement(transform, shelterPosition, enemyConfig);
        }
    }
}