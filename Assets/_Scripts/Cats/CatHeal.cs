using UnityEngine;

public class CatHeal : BaseCat
{
  private int _healAmount = 50;
  private float _healingTimer;
  private const float HEALING_TIMER_MAX = 10f;


  protected override void DefaultAction()
  {
    _healingTimer -= Time.deltaTime;
    if (_healingTimer <= 0)
    {
     Healing(); 
      _healingTimer = HEALING_TIMER_MAX;
    }
  }
  protected override void SecondTierAction()
  {
       
  }

  protected override void ThirdTierAction()
  {
    Debug.Log("Third Tier action");
  }

  private void Healing()
  {
    GridManager.Instance.GetRandomCatFromGrid().TakeHealing(_healAmount);
  }
  
  
  
}
