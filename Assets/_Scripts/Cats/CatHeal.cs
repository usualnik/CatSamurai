using System;
using UnityEngine;

public class CatHeal : BaseCat
{
  //[SerializeField] private int _healAmount = 10;
  [SerializeField] private float _healingCooldown = 2f;


  protected override void PerformAction()
  {
    _healingCooldown -= Time.deltaTime;
    if (_healingCooldown <= 0)
    {
     Healing(); 
      _healingCooldown = 2f;
    }
  }

  private void Healing()
  {
   
  }
  
  
  
}
