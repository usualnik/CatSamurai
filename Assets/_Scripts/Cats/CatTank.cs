using UnityEngine;

public class CatTank : BaseCat
{
  [SerializeField] private int _tankCatHealth = 300;

  public override void TakeDamage(int damage)
  {
    _tankCatHealth -= damage;
    if (_tankCatHealth <= 0)
    {
      Death();
    }
  }
}
