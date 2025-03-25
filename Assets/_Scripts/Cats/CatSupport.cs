using System;
using UnityEngine;

public class CatSupport : BaseCat
{
  
  //[SerializeField] private int _farmSushiAmount = 10;
  [SerializeField] private float _farmSushiCooldown = 2f;


  protected override void PerformAction()
  {
    _farmSushiCooldown -= Time.deltaTime;
    if (_farmSushiCooldown <= 0)
    {
     FarmingSushi(); 
      _farmSushiCooldown = 2f;
    }
  }

  private void FarmingSushi()
  {
    Debug.Log("Farm");
  }
  
  
  
}
