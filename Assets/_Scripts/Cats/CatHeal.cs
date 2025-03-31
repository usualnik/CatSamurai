using UnityEngine;

public class CatHeal : BaseCat
{
  private int _healAmount = 50;
  private float _healingTimer;
  private const float HEALING_TIMER_MAX = 10f;

  
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
        _healAmount = 60;
        break;
      case 3:
        _healAmount = 70;
        break;
    }
  }
  
  protected override void DefaultAction()
  {
    Healing();
  }
  protected override void SecondTierAction()
  {
    Healing();
  }

  protected override void ThirdTierAction()
  {
    Healing();
  }
  
  private void Healing()
  {
    _healingTimer -= Time.deltaTime;
    if (_healingTimer <= 0)
    {
      GridManager.Instance.GetRandomCatFromGrid().TakeHealing(_healAmount);
      _healingTimer = HEALING_TIMER_MAX;
    }
    
  }
  
  
  
}
