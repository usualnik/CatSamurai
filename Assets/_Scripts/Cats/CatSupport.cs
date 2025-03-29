using UnityEngine;

public class CatSupport : BaseCat
{
  private int _farmSushiAmount = 25;
  private float _farmSushiTimer;
  private const float FARM_SUSHI_TIMER_MAX = 10f;
  
  protected override void DefaultAction()
  {
    _farmSushiTimer -= Time.deltaTime;
    if (_farmSushiTimer <= 0)
    {
     FarmingSushi(); 
      _farmSushiTimer = FARM_SUSHI_TIMER_MAX;
    }
  }
  
  protected override void SecondTierAction()
  {
       
  }

  protected override void ThirdTierAction()
  {
    Debug.Log("Third Tier action");
  }

  private void FarmingSushi()
  {
    SushiManager.Instance.AddSushi(_farmSushiAmount);
  }
  
  
  
}
