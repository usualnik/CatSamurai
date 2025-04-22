using UnityEngine;

public class CatTank : BaseCat
{
   
    //Third Tier
    [Header("Third tier")]
    [SerializeField] private Transform _raycastPos;
     private float _meleeAttackDistance = 100f;
     private float _attackCooldownTimer;
     private const float ATTACK_COOLDOWN = 5f;

     private int _meleeDamage = 25;

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
                 SecondTierAction();
                 // + new visuals
                 break;
             case 3:
                 ThirdTierAction();
                 break;
         }
     }

     private new void SecondTierAction()
    {
        // bigger prefab animation
    }

     private new void ThirdTierAction()
     {
         InvokeRepeating(nameof(Attack),0,ATTACK_COOLDOWN);
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
                baseRacoon.TakeDamage(_meleeDamage);

            }
    }
}


