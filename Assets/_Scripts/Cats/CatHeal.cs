using Unity.Mathematics;
using UnityEngine;

public class CatHeal : BaseCat
{
  [SerializeField] private GameObject _healParticleSystem;
  
  private int _healAmount = 50;
  private float _healingTimer;
  private const float HEALING_TIMER_MAX = 10f;

  private readonly Vector3 _healPosOffset = new Vector3(0,200,0);
  
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
      if (SFX.Instance != null)
      {
        SFX.Instance.PlayHealSound();
      }

      BaseCat catToHeal = GridManager.Instance.GetRandomCatFromGrid();
      catToHeal.TakeHealing(_healAmount);
      
      Instantiate(_healParticleSystem, catToHeal.transform.position + _healPosOffset, quaternion.identity, catToHeal.transform);
      
      _healingTimer = HEALING_TIMER_MAX;
    }
    
  }
  
  
  
}
