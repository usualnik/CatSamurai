using UnityEngine;

public class CatSupport : BaseCat
{
  private int _farmSushiAmount = 25;
  private float _farmSushiTimer;
  private const float FARM_SUSHI_TIMER_MAX = 10f;
  
  private void Start()
  {
    OnLevelUp += BaseCat_OnLevelUp;
  }

  private void OnDestroy()
  {
    OnLevelUp -= BaseCat_OnLevelUp;
  }

  private void BaseCat_OnLevelUp(object sender, OnLevelUpEventArgs e)
  {
    switch (e.Level)
    {
      case 2:
        _farmSushiAmount = 35;
        break;
      case 3:
        _farmSushiAmount = 45;
        break;
    }
  }
  
  
  protected override void DefaultAction()
  {
    FarmingSushi();
  }
  
  protected override void SecondTierAction()
  {
       FarmingSushi();
  }

  protected override void ThirdTierAction()
  {
    FarmingSushi();
  }

  private void FarmingSushi()
  {
    _farmSushiTimer -= Time.deltaTime;
    if (_farmSushiTimer <= 0)
    {
      SushiManager.Instance.AddSushi(_farmSushiAmount);
      _farmSushiTimer = FARM_SUSHI_TIMER_MAX;
    }
  }
  
  
  
}
