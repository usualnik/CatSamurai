using System.Collections;
using UnityEngine;

public class RacoonMeleeAttack : MonoBehaviour
{
    [SerializeField] private float _attackCooldown = 2f;
    [SerializeField] private int _meleeDamage = 50;

    
    private RacoonMover _racoonMover;
    private RacoonsAnimation _racoonsAnimation;

    //private bool _isAttackOnCooldown;
    private BaseCat _currentCat;

    
    private void Start()
    {
       _racoonMover = GetComponentInParent<RacoonMover>();
       _racoonsAnimation = GetComponentInParent<RacoonsAnimation>();
       
       gameObject.layer = GetComponentInParent<BaseRacoon>().gameObject.layer;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (_isAttackOnCooldown) return;
        
        if (other.TryGetComponent(out BaseCat cat) && other.gameObject.layer == gameObject.layer)
        {
            _currentCat = cat;
            StartCoroutine(Attack());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out BaseCat _))
        {
            _racoonMover.CanMove(true);
            _racoonsAnimation.PlayAttackAnimation(false);
        }
    }

    private IEnumerator Attack()
    {
        //_isAttackOnCooldown = true;
        _racoonMover.CanMove(false);

        if (SFX.Instance != null)
            SFX.Instance.PlayRandomMeleeAttackSound();

        _racoonsAnimation.PlayAttackAnimation(true);
        _currentCat.TakeDamage(_meleeDamage);
        
        yield return new WaitForSeconds(_attackCooldown);
        //_isAttackOnCooldown = false;
        
        if (_currentCat != null && GetComponent<Collider2D>().IsTouching(_currentCat.GetComponent<Collider2D>()))
        {
            StartCoroutine(Attack());
        }
    }
}
