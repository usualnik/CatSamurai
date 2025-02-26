using UnityEngine;

public class Cat : MonoBehaviour
{
  public bool IsPlaced;
  public CatDataSO CatDataSo;

  [Header("MAGE")]

  #region Mage

  [SerializeField]
  private GameObject _mageBulletPrefab;

  [SerializeField] private Transform _spawnMageBulletPosition;
  private float _mageAttackCooldown = 3f;

  #endregion

  private enum BehaviourType
  {
    Mage,
    Archer,
    Tank
  }

  [SerializeField] private BehaviourType _behaviour;

  private void Update()
  {
    if (IsPlaced)
    {
      switch (_behaviour)
      {
        case BehaviourType.Mage:
          MageBehaviour();
          break;
        case BehaviourType.Archer:
          break;
        case BehaviourType.Tank:
          break;
      }
    }    
  }


  private void MageBehaviour()
  {
    _mageAttackCooldown -= Time.deltaTime;
    if (_mageAttackCooldown <= 0)
    {
      Instantiate(_mageBulletPrefab, _spawnMageBulletPosition.position, Quaternion.identity, transform);
      _mageAttackCooldown = 3f;
    }


  }
  
  
  
  
  
  
  
}
