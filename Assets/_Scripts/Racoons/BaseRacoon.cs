using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RacoonsAnimation))]
public class BaseRacoon : MonoBehaviour
{
   public RacoonDataSO RacoonDataSo;
   public int PercentSpawnChance;

   public static event EventHandler OnAnyRacoonDeath;
   
   private float _health;
   private LayerMask _layer;

   private RacoonsAnimation _racoonsAnimation;


   private void Awake()
   {
      _health = RacoonDataSo.RacoonHealth;
      _layer = gameObject.layer;
   }

   private void Start()
   {
      _racoonsAnimation = GetComponent<RacoonsAnimation>();
   }

   private IEnumerator WaitToDestroy()
   {
      yield return new WaitForSeconds(1.5f);
      Destroy(gameObject);
   }

   public void TakeDamage(int damage)
   {
      _health -= damage;
      if (_health <= 0)
      {
         OnAnyRacoonDeath?.Invoke(this, EventArgs.Empty);
         _racoonsAnimation.PlayDeathAnimation();

         StartCoroutine(WaitToDestroy());
      }
   }

   public LayerMask GetRacoonLayer()
   {
      return _layer;
   }
   

}
