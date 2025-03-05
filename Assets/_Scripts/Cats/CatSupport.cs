using UnityEngine;

public class CatSupport : BaseCat
{
  [SerializeField] private int _supportCatHealth = 50;
  //[SerializeField] private int _farmSushiAmount = 10;
  [SerializeField] private float _farmSushiCooldown = 2f;

  public override void TakeDamage(int damage)
  {
    _supportCatHealth -= damage;
    if (_supportCatHealth <= 0)
    {
      Destroy(gameObject);
    }
  }

  protected override void PerformAction()
  {
    Debug.Log("SUPPORT ACTION");
    
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
