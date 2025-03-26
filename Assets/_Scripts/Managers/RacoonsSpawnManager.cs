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
    
    [SerializeField] private int _spawnRacoonsLeftAmount;
    [SerializeField] private float _spawnTimer;
    private int _racoonOnSceneLeftAmount;
    
    
    private bool _isCanSpawn;

    
    private float _waveTimer;
    private float _betweenSpawnsTimer = 2;
    private int _waveAmount;
    
    //private int _waveMultiplier; // this handles more racoons spawning in future levels;
    
    private void Awake()
    {
        Instance = this;
        
        _waveTimer = GetNewWaveTimer();
        _waveAmount = GetNewWaveAmount();
        _betweenSpawnsTimer = GetNewBetweenSpawnTimer();
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

    private void SpawnWaveHandler()
    {
        _waveTimer -= Time.deltaTime;
       
        if ( _isCanSpawn && _waveTimer <= 0 && _spawnRacoonsLeftAmount > 0)
        {
            _betweenSpawnsTimer -= Time.deltaTime;
           
            if (_betweenSpawnsTimer <= 0 && _waveAmount > 0)
            {
                SpawnSingleRacoon();
                _betweenSpawnsTimer = GetNewBetweenSpawnTimer();
                _waveAmount--;
               
                if (_waveAmount <= 0)
                {
                    _waveTimer = GetNewWaveTimer();
                    _waveAmount = GetNewWaveAmount();
                }
            }
           
        }
    }

    private float GetNewWaveTimer()
    {
        return Random.Range(50, 70);
    }

    private int GetNewWaveAmount()
    {
        return Random.Range(10, 20);
    }

    private int GetNewBetweenSpawnTimer()
    {
        return Random.Range(1,6);
    }

    private void SpawnSingleRacoonsHandler()
    {
        _spawnTimer -= Time.deltaTime;
        
        if (_isCanSpawn && _spawnTimer <= 0 && _spawnRacoonsLeftAmount > 0)
        {
            SpawnSingleRacoon();
            _spawnTimer = Random.Range(10f,30f);
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
