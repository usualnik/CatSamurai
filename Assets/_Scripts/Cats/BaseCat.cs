using System;
using UnityEngine;

public class BaseCat : MonoBehaviour
{
  [SerializeField] private bool _isPlaced;
  public event EventHandler OnCatDeath;

  public CatDataSO CatDataSo;

  private void Update()
  {
    if (_isPlaced)
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

  protected void Death()
  {
    Debug.Log("Death");
    OnCatDeath?.Invoke(this,EventArgs.Empty);
    Destroy(gameObject);
  }

  public void SetPlaced(bool isPlaced)
  {
    _isPlaced = isPlaced;
  }



}
