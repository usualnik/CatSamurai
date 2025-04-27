using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RacoonsSpawnManager : MonoBehaviour
{
    public static RacoonsSpawnManager Instance { get; private set; }
    
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private RectTransform[] _racoonSpawnPoints;

    [SerializeField] private BaseRacoon[] _racoonsPrefabs;

    [Header("Spawn Chances")] 
    
    [Tooltip("ALL CHANCES MUST ADDS UP TO 100")] [SerializeField] private int _element0;
    [Tooltip("ALL CHANCES MUST ADDS UP TO 100")] [SerializeField] private int _element1;
    [Tooltip("ALL CHANCES MUST ADDS UP TO 100")] [SerializeField] private int _element2;

    [Header("General Spawn Properties")]
    
    [SerializeField] [Tooltip("The number of Raccoons on the scene")] private int _spawnRacoonsLeftAmount;

    //Single
    [SerializeField] [Range(0,100)] [Tooltip("Min timer value to spawn single racoon")] private float _spawnTimerMin;
    [SerializeField] [Range(0,100)] [Tooltip("Max timer value to spawn single racoon")] private float _spawnTimerMax;
    
    
    [Header("Wave Spawn Properties")]
    //Wave
    [SerializeField] [Range(0,100)] [Tooltip("Min timer value to spawn new racoon wave")] private float _waveTimerMin;
    [SerializeField] [Range(0,100)] [Tooltip("Max timer value to spawn new racoon wave")] private float _waveTimerMax;
    [SerializeField] [Range(0,100)] [Tooltip("Min timer value to spawn racoon in wave")] private float _inWaveSpawnTimerMin;
    [SerializeField] [Range(0,100)] [Tooltip("Max timer value to spawn racoon in wave")] private float _inWaveSpawnTimerMax;
    
    [SerializeField] [Tooltip("Min value of racoons in wave")] private int _amountOfRacoonsInWaveMin;
    [SerializeField] [Tooltip("Max value of racoons in wave")] private int _amountOfRacoonsInWaveMax;
    
    
    private float _spawnTimer;
    [SerializeField] private int _racoonOnSceneLeftAmount;
    private bool _isCanSpawn;
    private float _waveTimer;
    private float _betweenSpawnsTimer;
    private int _waveAmount;
    
    //private int _waveMultiplier; // this handles more racoons spawning in future levels;
    
    private void Awake()
    {
        Instance = this;
        
        _waveTimer = GetNewWaveTimer();
        _waveAmount = GetNewWaveAmount();
        _betweenSpawnsTimer = GetNewBetweenSpawnInWaveTimer();
        _spawnTimer = 1f;
        _racoonOnSceneLeftAmount = _spawnRacoonsLeftAmount;

    }

    private void Start()
    {
        BaseRacoon.OnAnyRacoonDeath += StaticEvent_BaseRacoon_OnAnyRacoonDeath;
       UICatSetupMenu.Instance.OnCatSetupApproved += UICatSetupMenu_OnCatSetupApproved;
       InitializeSpawnChances();
    }

  
    private void OnDestroy()
    {
        UICatSetupMenu.Instance.OnCatSetupApproved -= UICatSetupMenu_OnCatSetupApproved;
        BaseRacoon.OnAnyRacoonDeath -= StaticEvent_BaseRacoon_OnAnyRacoonDeath;
    }
    
    private void StaticEvent_BaseRacoon_OnAnyRacoonDeath(object sender, EventArgs e)
    {
        SubtractRacoon();
    }

    private void UICatSetupMenu_OnCatSetupApproved(object sender, EventArgs e)
    { 
        _isCanSpawn = true;
        
    }

    private void InitializeSpawnChances()
    {
        _racoonsPrefabs[0].PercentSpawnChance = _element0;
        _racoonsPrefabs[1].PercentSpawnChance = _element1;
        _racoonsPrefabs[2].PercentSpawnChance = _element2;
    }

    private void Update()
    {
       SpawnSingleRacoonsHandler();
       SpawnWaveHandler();
       
    }
    
    private float GetNewWaveTimer()
    {
        return Random.Range(_waveTimerMin, _waveTimerMax);
    }
    private float GetNewBetweenSpawnInWaveTimer()
    {
        return Random.Range(_inWaveSpawnTimerMin,_inWaveSpawnTimerMax);
    }
    private float GetNewSpawnTimer()
    {
        return Random.Range(_spawnTimerMin,_spawnTimerMax);
    }
    private int GetNewWaveAmount()
    {
        return Random.Range(_amountOfRacoonsInWaveMin, _amountOfRacoonsInWaveMax + 1);
    }
    
    private void SpawnWaveHandler()
    {
        _waveTimer -= Time.deltaTime;
       
        if ( _isCanSpawn && _waveTimer <= 0 && _spawnRacoonsLeftAmount > 0)
        {
            _betweenSpawnsTimer -= Time.deltaTime;
           
            if (_betweenSpawnsTimer <= 0 && _waveAmount > 0)
            {
                SpawnSingleRacoon();
                _betweenSpawnsTimer = GetNewBetweenSpawnInWaveTimer();
                _waveAmount--;
               
                if (_waveAmount <= 0)
                {
                    _waveTimer = GetNewWaveTimer();
                    _waveAmount = GetNewWaveAmount();
                }
            }
           
        }
    }
    private void SpawnSingleRacoonsHandler()
    {
        _spawnTimer -= Time.deltaTime;
        
        if (_isCanSpawn && _spawnTimer <= 0 && _spawnRacoonsLeftAmount > 0)
        {
            SpawnSingleRacoon();
            _spawnTimer = GetNewSpawnTimer();
        }
    }
  
    private void SpawnSingleRacoon()
    {
        _spawnRacoonsLeftAmount--;
        int _randomSpawnPos = Random.Range(0, _racoonSpawnPoints.Length);
        
        int randomChance = Random.Range(0, 101);
        int cumulativeChance = 0;

        foreach (var racoon in _racoonsPrefabs)
        {
            cumulativeChance = cumulativeChance + racoon.PercentSpawnChance;
            
            if (randomChance <= cumulativeChance)
            {
                GameObject newRacoon = Instantiate(racoon.gameObject, _racoonSpawnPoints[_randomSpawnPos]);
                newRacoon.layer = _racoonSpawnPoints[_randomSpawnPos].gameObject.layer;
                newRacoon.transform.position = _racoonSpawnPoints[_randomSpawnPos].transform.position;
              
                break;
            }
        }
    }

    private void SubtractRacoon()
    {
        _racoonOnSceneLeftAmount--;
    }


    public int GetRacoonsLeftAmount()
    {
        return _racoonOnSceneLeftAmount;
    }
    
    
    
    
    
    
}
