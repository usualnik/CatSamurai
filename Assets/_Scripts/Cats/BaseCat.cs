using System;
using UnityEngine;

public class BaseCat : MonoBehaviour
{
  [SerializeField] private GameObject _removeIcon;

  public event EventHandler OnCatDeath;
  public event EventHandler OnCatPlaced;
  public event EventHandler OnTakingDamage;
  public event EventHandler OnTakingHealing;
  public event EventHandler<XpGainedEventArgs> OnXpGained;
  public class XpGainedEventArgs : EventArgs
  {
    public float CurrentXpGained;
  }
  public event EventHandler<OnLevelUpEventArgs> OnLevelUp;

  public class OnLevelUpEventArgs : EventArgs
  {
    public int Level;
  }
  public CatDataSO CatDataSo;
  [SerializeField] private float _currentCatHealth;
  [HideInInspector] public float _maxCatHealth;
  
  private bool _isPlaced;
  private GridCell _currentGridCell;
  
  private float _gainXpSpeed = 0.025f;
   //private float _gainXpSpeed = 0.5f; // Debug speed
  private float _gainXpNewLevelModifier = 0.5f;
  
  private float _currentXp;
  private float _maxXpToLvlUp;

  private int _catLevel;
  private const int MAX_LEVEL_CAP = 3;

  private BoxCollider2D _catCollider;

  private void Awake()
  {
    _catLevel = 1;
    _currentXp = 0f;
    _maxXpToLvlUp = 1f;

    _maxCatHealth = CatDataSo.CatHealth;
    _currentCatHealth = _maxCatHealth;
    _catCollider = gameObject.GetComponent<BoxCollider2D>();
  }

  private void Update()
  {

    if (_isPlaced)
    {
      switch (_catLevel)
      {
        default:
          DefaultAction();
          break;
        case 2:
          SecondTierAction();
          break;
        case 3:
          ThirdTierAction();
          break;
      }
      
      if (_catLevel < MAX_LEVEL_CAP)
      {
        GainXp();
      }
    }

  }

  private void GainXp()
  {
    _currentXp += Time.deltaTime * _gainXpSpeed;
    OnXpGained?.Invoke(this,new XpGainedEventArgs(){CurrentXpGained = _currentXp});
   
    if (_currentXp >= _maxXpToLvlUp)
    {
      LevelUp();
    }
  }
  private void LevelUp()
  {
    if (SFX.Instance != null)
    {
      SFX.Instance.PlayLevelUpSound();
    }
    
    _catLevel++;
    _currentXp = 0;
    _gainXpSpeed = _gainXpSpeed * _gainXpNewLevelModifier;
    OnLevelUp?.Invoke(this,new OnLevelUpEventArgs(){Level = _catLevel});
  }
  protected virtual void SecondTierAction()
  {
    
  }
  protected virtual void ThirdTierAction()
  {
    
  }

  protected virtual void DefaultAction()
  {
    
  }
  
  protected void Death()
  {
    OnCatDeath?.Invoke(this,EventArgs.Empty);
    Destroy(gameObject);
  }



  
  public float GetCurrentHealth()
  {
    return _currentCatHealth;
  }

  public void TakeDamage(int damage)
  {
    _currentCatHealth -= damage;
    if (_currentCatHealth <= 0)
    {
      Death();
    }
    
    OnTakingDamage?.Invoke(this,EventArgs.Empty);
  }
  public void TakeHealing(int healAmount)
  {
    if(_currentCatHealth < _maxCatHealth)
    {
      _currentCatHealth += healAmount;
      OnTakingHealing?.Invoke(this, EventArgs.Empty);
    }
    else if (_currentCatHealth > _maxCatHealth)
    {
      _currentCatHealth = _maxCatHealth;
    }
  }


  public void SetPlaced(bool isPlaced)
  {
    _isPlaced = isPlaced;
    _catCollider.enabled = true;
    OnCatPlaced?.Invoke(this,EventArgs.Empty);
  }
  public bool IsPlaced{ get => _isPlaced;}

  public void SetGridCell(GridCell gridCell)
  {
    _currentGridCell = gridCell;
  }

  public GridCell GetGridCell()
  {
    return _currentGridCell;
  }

  public void RemoveFromField()
  {
    Destroy(gameObject);
  }

  public void ShowRemoveIcon()
  {
    _removeIcon.gameObject.SetActive(true);
  }
  public void HideRemoveIcon()
  {
    _removeIcon.gameObject.SetActive(false);
  }


}
