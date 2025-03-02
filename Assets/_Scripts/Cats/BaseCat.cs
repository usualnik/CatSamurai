using System;
using UnityEngine;

public class BaseCat : MonoBehaviour
{
  public bool IsPlaced;
  public CatDataSO CatDataSo;


  private void Update()
  {
    if (IsPlaced)
    {
      PerformAction();
    }
  }

  protected virtual void PerformAction()
  {
    
  }
  
  public virtual void TakeDamage(int damage)
  {
    
  }

}
