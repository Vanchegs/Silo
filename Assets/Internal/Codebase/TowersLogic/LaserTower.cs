using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.Codebase
{
    public class LaserTower : MonoBehaviour
    { 
        [Header("Combat Settings")]
        [SerializeField] private float range;
        [SerializeField] private float damagePerSecond;
        [SerializeField] private int maxAmmo;
        [SerializeField] private LayerMask enemyLayer; 

        [Header("Visuals")]
        
        [SerializeField] private float laserAppearDuration;
        [SerializeField] private float laserDisappearDuration;
        [SerializeField] private Color activeLaserColor;
        [SerializeField] private Color depletedLaserColor;
        [SerializeField] private Transform laserStartPosition;

        [Header("UI")] 
        [SerializeField] private Canvas towerCanvas;
        [SerializeField] private Button towerButton;
        
        private LineRenderer laserLine;
        private float currentAmmo;
        private float ammoConsumptionRate = 1f;
        private Transform target;
        private float fireTimer;
        private Tween laserFadeTween;
        private bool isActive = true;
        private bool isApplyingDamage;
        private Enemy currentTarget;

        private void Start()
        {
            currentAmmo = maxAmmo;
            InitializeLaser();
        }

        private void Update()
        {
            if (!isActive || currentAmmo <= 0) 
            {
                if (laserLine.enabled) DisappearLaser();
                return;
            }

            FindNearestEnemy();
            Shoot();
        }

        private void InitializeLaser()
        {
            laserLine = GetComponent<LineRenderer>();
            laserLine.startColor = activeLaserColor;
            laserLine.endColor = activeLaserColor;
            laserLine.startWidth = 0.2f;
            laserLine.endWidth = 0.2f;
        }

        private void Shoot()
        {
            if (target == null) 
            {
                if (laserLine.enabled) 
                    DisappearLaser();
                return;
            }
            
            laserLine.SetPosition(0, laserStartPosition.position);
            laserLine.SetPosition(1, target.position);
    
            if (!laserLine.enabled) 
                AppearLaser();

            if (!isApplyingDamage) 
                ApplyDamageToTarget();

            currentAmmo -= Time.deltaTime * ammoConsumptionRate;
    
            if (currentAmmo <= 0)
            {
                currentAmmo = 0;
                OnAmmoDepleted();
            }
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
            if (isApplyingDamage || target == null) return;

            currentTarget = target.GetComponent<Enemy>();
            if (currentTarget == null) return;

            isApplyingDamage = true;
            float damageInterval = 0.1f;

            InvokeRepeating(nameof(DealDamageOverTime), 0f, damageInterval);
        }
        
        private void DealDamageOverTime()
        {
            if (currentTarget == null || Vector2.Distance(transform.position, currentTarget.transform.position) > range)
            {
                CancelInvoke(nameof(DealDamageOverTime));
                isApplyingDamage = false;
                DisappearLaser();
                return;
            }

            currentTarget.TakeDamage(damagePerSecond * 0.1f);
        }

        private void OnAmmoDepleted()
        {
            laserLine.startColor = depletedLaserColor;
            laserLine.endColor = depletedLaserColor;
            isActive = false;
            towerCanvas.gameObject.SetActive(true);
            towerButton.transform.DOLocalMoveY(0,0.5f).From(-0.5f).SetEase(Ease.OutBack);
            
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
            towerButton.transform.DOLocalMoveY(-0.5f,0.2f).From(0).SetEase(Ease.Flash)
                .OnComplete(() => {towerButton.gameObject.SetActive(false);});
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