using UnityEngine;

namespace Internal.Codebase
{
    public class Mutant : Enemy
    {
        private Vector2 direction;
        
        private void FixedUpdate() => 
            movement.Move();
    }
}