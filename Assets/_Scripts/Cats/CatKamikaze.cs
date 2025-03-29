using UnityEngine;

public class CatKamikaze : BaseCat
{
    [SerializeField] private Transform _raycastPos;
    [SerializeField] private float _meleeAttackDistance = 100f;
    [SerializeField] private float _attackCooldown = 2f;
    
    [SerializeField] private int _meleeDamage = 50;
  
    protected override void DefaultAction()
    {
        Attack();
    }
    protected override void SecondTierAction()
    {
       
    }

    protected override void ThirdTierAction()
    {
        Debug.Log("Third Tier action");
    }

    private void Attack()
    {
        _attackCooldown -= Time.deltaTime;
        if (_attackCooldown <= 0)
        {
            Vector2 rayOrigin = new Vector2(_raycastPos.position.x,_raycastPos.position.y);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(rayOrigin, Vector2.right, _meleeAttackDistance);
            
            if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject.layer == gameObject.layer 
                                              && raycastHit2D.collider.TryGetComponent(out BaseRacoon baseRacoon))
            {
                baseRacoon.TakeDamage(_meleeDamage);
            }
            _attackCooldown = 2f;
        }
    }

}
