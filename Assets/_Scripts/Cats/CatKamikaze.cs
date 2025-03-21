using UnityEngine;

public class CatKamikaze : BaseCat
{
    [SerializeField] private Transform _raycastPos;
    [SerializeField] private float _meleeAttackDistance = 100f;
    [SerializeField] private float _attackCooldown = 2f;
    
    [SerializeField] private int _meleeDamage = 50;
    [SerializeField] private int _kamikazeCatHealth = 150;

    private void Update()
    {
        Attack();
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

    public override void TakeDamage(int damage)
    {
        _kamikazeCatHealth -= damage;
        if (_kamikazeCatHealth <= 0)
        {
            Death();
        }
    }

}
