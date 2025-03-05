using UnityEngine;

public class BaseCat : MonoBehaviour
{
  [SerializeField] private bool _isPlaced;

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

  public void SetPlaced(bool isPlaced)
  {
    _isPlaced = isPlaced;
  }



}
