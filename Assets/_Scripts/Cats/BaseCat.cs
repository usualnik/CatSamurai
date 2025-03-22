using System;
using UnityEngine;

public class BaseCat : MonoBehaviour
{
  [SerializeField] private GameObject _removeIcon;
  
  public event EventHandler OnCatDeath;

  public CatDataSO CatDataSo;
  
  private bool _isPlaced;
  private GridCell _currentGridCell;
  

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
    OnCatDeath?.Invoke(this,EventArgs.Empty);
    Destroy(gameObject);
  }

  public void SetPlaced(bool isPlaced)
  {
    _isPlaced = isPlaced;
  }

  public void SetGridCell(GridCell gridCell)
  {
    _currentGridCell = gridCell;
  }

  public GridCell GetGridCell()
  {
    return _currentGridCell;
  }

  public void RemoveFromField()
  {
    Destroy(gameObject);
  }

  public void ShowRemoveIcon()
  {
    _removeIcon.gameObject.SetActive(true);
  }
  public void HideRemoveIcon()
  {
    _removeIcon.gameObject.SetActive(false);
  }



}
