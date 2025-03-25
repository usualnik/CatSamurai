using System;
using UnityEngine;

public class BaseCat : MonoBehaviour
{
  [SerializeField] private GameObject _removeIcon;

 
  
  public event EventHandler OnCatDeath;
  public event EventHandler OnTakingDamage;
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
  public float _currentCatHealth;
  [HideInInspector] public float _maxCatHealth;
  
  private bool _isPlaced;
  private GridCell _currentGridCell;
  
  //private float _gainXpModifier = 0.01f;
  private float _gainXpSpeed = 0.1f;
  private float _gainXpNewLevelModifier = 0.5f;
  
  private float _currentXp;
  private float _maxXpToLvlUp;

  private int _catLevel;

  private void Awake()
  {
    _catLevel = 1;
    _currentXp = 0f;
    _maxXpToLvlUp = 1f;

    _maxCatHealth = CatDataSo.CatHealth;
    _currentCatHealth = _maxCatHealth;
  }

  private void Update()
  {
    if (_isPlaced)
    {
      PerformAction();
      GainXp();
    }

  }

  protected virtual void PerformAction()
  {
    
  }

  public virtual void TakeDamage(int damage)
  {
    _currentCatHealth -= damage;
    if (_currentCatHealth <= 0)
    {
      Death();
    }
    
    OnTakingDamage?.Invoke(this,EventArgs.Empty);
  }

  protected void Death()
  {
    OnCatDeath?.Invoke(this,EventArgs.Empty);
    Destroy(gameObject);
  }

  public void SetPlaced(bool isPlaced)
  {
    _isPlaced = isPlaced;
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
   
    _catLevel++;
    _currentXp = 0;
    _gainXpSpeed = _gainXpSpeed * _gainXpNewLevelModifier;
    OnLevelUp?.Invoke(this,new OnLevelUpEventArgs(){Level = _catLevel});
    
  }


}
