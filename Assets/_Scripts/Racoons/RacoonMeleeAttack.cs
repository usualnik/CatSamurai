using System;
using System.Collections;
using UnityEngine;

public class RacoonMeleeAttack : MonoBehaviour
{
    [SerializeField] private Transform _raycastPos;
    [SerializeField] private float _meleeAttackDistance = 100f;
    [SerializeField] private float _attackCooldown;

    [SerializeField] private int _meleeDamage = 50;

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        _attackCooldown -= Time.deltaTime;
        if (_attackCooldown <= 0)
        {
            Vector2 rayOrigin = new Vector2(_raycastPos.position.x, _raycastPos.position.y);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(rayOrigin, Vector2.left, _meleeAttackDistance);

            if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject.layer == gameObject.layer
                                              && raycastHit2D.collider.TryGetComponent(out BaseCat baseCat))
            {
                gameObject.GetComponent<RacoonMover>().CanMove(false);
                baseCat.TakeDamage(_meleeDamage);
            }
            else
            {
                gameObject.GetComponent<RacoonMover>().CanMove(true);
            }
            _attackCooldown = 2f;
        }

    }
}



