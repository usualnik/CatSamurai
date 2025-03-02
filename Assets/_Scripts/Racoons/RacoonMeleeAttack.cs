using System.Collections;
using UnityEngine;

public class RacoonMeleeAttack : MonoBehaviour
{
    [SerializeField] private Transform _raycastPos;
    [SerializeField] private float _meleeAttackDistance = 100f;
    [SerializeField] private float _attackCooldown = 2f;
    
    [SerializeField] private int _meleeDamage = 50;

        private void Start()
    {
        InvokeRepeating(nameof(CheckForAttack),0f,1f);
    }

    private void CheckForAttack()
    {
        Vector2 rayOrigin = new Vector2(_raycastPos.position.x,_raycastPos.position.y);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(rayOrigin, Vector2.left, _meleeAttackDistance);

        if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject.layer == gameObject.layer 
                                          && raycastHit2D.collider.TryGetComponent(out BaseCat baseCat))
        {
            gameObject.GetComponent<RacoonMover>().CanMove(false);
            StartCoroutine(DealMeleeDamage(baseCat));
        }
        else
        {
            gameObject.GetComponent<RacoonMover>().CanMove(true);
        }
        
    }

    private IEnumerator DealMeleeDamage(BaseCat baseCat)
    {
        yield return new WaitForSeconds(_attackCooldown);
        Debug.Log("DEALING DAMAGE");
        baseCat?.TakeDamage(_meleeDamage);
    }

    
}
