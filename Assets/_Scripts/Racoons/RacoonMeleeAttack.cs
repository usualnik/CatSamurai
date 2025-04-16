using UnityEngine;

[RequireComponent(typeof(RacoonsAnimation))]
public class RacoonMeleeAttack : MonoBehaviour
{
    [SerializeField] private Transform _raycastPos;
    private Vector2 rayOrigin;
    private float _meleeAttackDistance = 50f;
    private const float ATTACK_COOLDOWN = 2f;
    private int _meleeDamage = 50;
    private RacoonsAnimation _racoonsAnimation;

    private void Start()
    {
        _racoonsAnimation = GetComponent<RacoonsAnimation>();
        InvokeRepeating(nameof(Attack), 0, ATTACK_COOLDOWN);
    }

    private void Attack()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(new Vector2(_raycastPos.position.x, _raycastPos.position.y), Vector2.left, _meleeAttackDistance);
        if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject.layer == gameObject.layer
                                          && raycastHit2D.collider.TryGetComponent(out BaseCat baseCat))
        {
            _racoonsAnimation.PlayAttackAnimation(true);
            baseCat.TakeDamage(_meleeDamage);
        }
        else
        {
            _racoonsAnimation.PlayAttackAnimation(false);
        }
            
    }
}




