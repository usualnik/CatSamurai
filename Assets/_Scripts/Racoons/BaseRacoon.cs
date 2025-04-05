using System;
using UnityEngine;

public class BaseRacoon : MonoBehaviour
{
   public RacoonDataSO RacoonDataSo;
   public int PercentSpawnChance;

   public static event EventHandler OnAnyRacoonDeath;
   
   private float _health;
   private LayerMask _layer;


   private void Awake()
   {
      _health = RacoonDataSo.RacoonHealth;
      _layer = gameObject.layer;
   }

   public void TakeDamage(int damage)
   {
      _health -= damage;
      if (_health <= 0)
      {
         OnAnyRacoonDeath?.Invoke(this, EventArgs.Empty);
         Destroy(gameObject);
      }
   }

   public LayerMask GetRacoonLayer()
   {
      return _layer;
   }
   

}
