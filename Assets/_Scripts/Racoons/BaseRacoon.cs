using System;
using UnityEngine;

public class BaseRacoon : MonoBehaviour
{
   public RacoonDataSO RacoonDataSo;
   public int PercentSpawnChance;

   public static event EventHandler OnAnyRacoonDeath;
   
   private float _health;

   private void Awake()
   {
      _health = RacoonDataSo.RacoonHealth;
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

}
