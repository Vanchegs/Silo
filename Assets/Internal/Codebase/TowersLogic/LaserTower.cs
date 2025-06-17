using DG.Tweening;
using UnityEngine;

namespace Internal.Codebase.TowersLogic
{
    public class LaserTower : MonoBehaviour
    { 
        [Header("Combat Settings")]
        [SerializeField] private float range;
        [SerializeField] private int damagePerSecond;
        [SerializeField] private float fireRate;
        [SerializeField] private int maxAmmo;
        [SerializeField] private LayerMask enemyLayer;

        [Header("Visuals")]
        [SerializeField] private LineRenderer laserLine;
        [SerializeField] private float laserAppearDuration;
        [SerializeField] private float laserDisappearDuration;
        [SerializeField] private Color activeLaserColor;
        [SerializeField] private Color depletedLaserColor;

        private int currentAmmo;
        private Transform target;
        private float fireTimer;
        private Tween laserFadeTween;
        private bool isActive = true;

        private void Start()
        {
            currentAmmo = maxAmmo;
            InitializeLaser();
        }

        private void Update()
        {
            if (!isActive || currentAmmo <= 0) return;

            FindNearestEnemy();

            if (target != null)
            {
                fireTimer += Time.deltaTime;
                if (fireTimer >= 1f / fireRate)
                {
                    Shoot();
                    fireTimer = 0f;
                }
            }
            else if (laserLine.enabled)
            {
                DisappearLaser();
            }
        }

        private void InitializeLaser()
        {
            laserLine.startColor = activeLaserColor;
            laserLine.endColor = activeLaserColor;
            laserLine.startWidth = 1f;
            laserLine.endWidth = 1f;
        }

        private void Shoot()
        {
            if (target == null) return;

            laserLine.SetPosition(1, transform.position);
            laserLine.SetPosition(1, target.position);
            
            AppearLaser();
            
            ApplyDamageToTarget();

            currentAmmo--;
            if (currentAmmo <= 0)
            {
                OnAmmoDepleted();
            }
            
            DOVirtual.DelayedCall(0.1f, DisappearLaser);
        }
        
        private void FindNearestEnemy()
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);
            float closestDistance = Mathf.Infinity;
            Transform nearestEnemy = null;

            foreach (Collider2D enemy in enemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestEnemy = enemy.transform;
                }
            }
            
            target = nearestEnemy;
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }

        private void ApplyDamageToTarget()
        {
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damagePerSecond);
            }
        }

        private void OnAmmoDepleted()
        {
            laserLine.startColor = depletedLaserColor;
            laserLine.endColor = depletedLaserColor;
            isActive = false;
            Debug.Log("Башня разряжена! Требуется перезарядка.");
        }

        public void Reload(int amount)
        {
            currentAmmo = Mathf.Min(currentAmmo + amount, maxAmmo);
            if (!isActive && currentAmmo > 0)
            {
                isActive = true;
                laserLine.startColor = activeLaserColor;
                laserLine.endColor = activeLaserColor;
            }
        }

        private void AppearLaser()
        {
            laserFadeTween?.Kill();
            laserLine.enabled = true;
        
            laserFadeTween = DOTween.To(
                () => laserLine.startWidth,
                x => laserLine.startWidth = laserLine.endWidth = x,
                0.2f,
                laserAppearDuration
            );
        }

        private void DisappearLaser()
        {
            if (!laserLine.enabled) return;
        
            laserFadeTween?.Kill();
        
            laserFadeTween = DOTween.To(
                () => laserLine.startWidth,
                x => laserLine.startWidth = laserLine.endWidth = x,
                0f,
                laserDisappearDuration
            ).OnComplete(() => laserLine.enabled = false);
        }
    }
}