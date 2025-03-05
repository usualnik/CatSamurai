using UnityEngine;

public class CatHeal : BaseCat
{
  [SerializeField] private int _healCatHealth = 50;
  //[SerializeField] private int _healAmount = 10;
  [SerializeField] private float _healingCooldown = 2f;

  public override void TakeDamage(int damage)
  {
    _healCatHealth -= damage;
    if (_healCatHealth <= 0)
    {
      Destroy(gameObject);
    }
  }

  protected override void PerformAction()
  {
    Debug.Log("HEALER ACTION");
    _healingCooldown -= Time.deltaTime;
    if (_healingCooldown <= 0)
    {
     Healing(); 
      _healingCooldown = 2f;
    }
  }

  private void Healing()
  {
    Debug.Log("Heal");
  }
  
  
  
}
