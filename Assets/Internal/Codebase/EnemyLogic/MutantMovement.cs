using UnityEngine;

namespace Internal.Codebase
{
    public class MutantMovement : IMovement
    {
        private Transform transform;
        private Vector3 shelterPosition;
        private int moveSpeed;
        private float stoppingDistance = 0.5f;
        private Rigidbody2D rb;
    
        public MutantMovement(Transform transform, int speed)
        {
            this.transform = transform;
            shelterPosition = new Vector2(0, 0);
            moveSpeed = speed;

            rb = transform.gameObject.GetComponent<Rigidbody2D>();

            rb.gravityScale = 0;
            rb.freezeRotation = true;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
    
        public void Move()
        {
            Vector2 direction = (shelterPosition - transform.position).normalized;
            
            if (direction != Vector2.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation, 
                    targetRotation, 
                    moveSpeed * Time.deltaTime
                );
            }
            
            float distanceToTarget = Vector2.Distance(transform.position, shelterPosition);
            if (distanceToTarget > stoppingDistance)
                rb.velocity = direction * moveSpeed;
            else
                rb.velocity = Vector2.zero;
        }
    }
}
