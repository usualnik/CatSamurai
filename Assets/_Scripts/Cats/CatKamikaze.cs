using System.Collections;
using UnityEngine;

public class CatKamikaze : BaseCat
{
    [SerializeField] private Transform _raycastPos;
    [SerializeField] private int _meleeDamage = 50;
    [SerializeField] private GameObject _meleeAttackPrefab;
    
    private int _secondTierMeleeDamage = 60;
    private int _thirdTierMeleeDamage = 70;
    
    private float _meleeAttackDistance = 50f;
    private const float ATTACK_COOLDOWN = 2f;
    
    private void Start()
    {
        OnLevelUp += BaseCat_OnLevelUp;
        InvokeRepeating(nameof(Attack), 0, ATTACK_COOLDOWN);
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
    private void Attack()
    {
            Vector2 rayOrigin = new Vector2(_raycastPos.position.x,_raycastPos.position.y);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(rayOrigin, Vector2.right, _meleeAttackDistance);
            
            if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject.layer == gameObject.layer 
                                              && raycastHit2D.collider.TryGetComponent(out BaseRacoon baseRacoon))
            {
                if (SFX.Instance != null)
                {
                    SFX.Instance.PlayRandomMeleeAttackSound();
                }
                _meleeAttackPrefab.SetActive(true);
                StartCoroutine(WaitForMeleeAttackAnim());
                baseRacoon.TakeDamage(_meleeDamage);
            }
            
    }

    private IEnumerator WaitForMeleeAttackAnim()
    {
        yield return new WaitForSeconds(1.5f);
        _meleeAttackPrefab.SetActive(false);
    }
    
}


