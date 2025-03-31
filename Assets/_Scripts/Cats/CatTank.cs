
using UnityEngine;

public class CatTank : BaseCat
{
    
    // Second Tier
    private readonly Vector3 _upgradedScale = new Vector3(0.1f,0.1f,0);
    private bool _canUpgradeToSecondTier = true;
    
    
    //Third Tier
    [Header("Third tier")]
    [SerializeField] private Transform _raycastPos;
     private float _meleeAttackDistance = 100f;
     private float _attackCooldownTimer;
     private const float ATTACK_COOLDOWN_TIMER_MAX = 5f;

     private int _meleeDamage = 25;
     
    
    protected override void SecondTierAction()
    {
        if (_canUpgradeToSecondTier)
        {
            gameObject.transform.localScale += _upgradedScale;
            _canUpgradeToSecondTier = false;
        }
    }

    protected override void ThirdTierAction()
    {
        Attack();
    }
    
    private void Attack()
    {
        _attackCooldownTimer -= Time.deltaTime;
        if (_attackCooldownTimer <= 0)
        {
            Vector2 rayOrigin = new Vector2(_raycastPos.position.x,_raycastPos.position.y);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(rayOrigin, Vector2.right, _meleeAttackDistance);
            
            if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject.layer == gameObject.layer 
                                              && raycastHit2D.collider.TryGetComponent(out BaseRacoon baseRacoon))
            {
                baseRacoon.TakeDamage(_meleeDamage);
                _attackCooldownTimer = ATTACK_COOLDOWN_TIMER_MAX;

            }
        }
    }

    
}
