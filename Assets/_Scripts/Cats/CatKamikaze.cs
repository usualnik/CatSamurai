using UnityEngine;

public class CatKamikaze : BaseCat
{
    [SerializeField] private Transform _raycastPos;
   
   [SerializeField] private int _meleeDamage = 50;
    private int _secondTierMeleeDamage = 60;
    private int _thirdTierMeleeDamage = 70;
    
    private float _meleeAttackDistance = 100f;
    private float _attackCooldownTimer;
    private const float ATTACK_COOLDOWN_TIMER_MAX = 2f;

    
  
    private void Start()
    {
        OnLevelUp += BaseCat_OnLevelUp;
    }

    private void OnDestroy()
    {
        OnLevelUp -= BaseCat_OnLevelUp;
    }

    private void BaseCat_OnLevelUp(object sender, OnLevelUpEventArgs e)
    {
        switch (e.Level)
        {
            case 2:
                _meleeDamage = _secondTierMeleeDamage;
                // + new visuals
                break;
            case 3:
                _meleeDamage = _thirdTierMeleeDamage;
                // + critical strike mechanic
                break;
        }
    }

    protected override void DefaultAction()
    {
        Attack();
    }
    protected override void SecondTierAction()
    {
       Attack();
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
