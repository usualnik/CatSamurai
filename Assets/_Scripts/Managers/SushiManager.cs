using System;
using TMPro;
using UnityEngine;

public class SushiManager : MonoBehaviour
{
    public static SushiManager Instance { get; private set; }
     
    [SerializeField] private int _sushi;    
    [SerializeField] private TextMeshProUGUI _sushiText;

    private float _farmSushiTimer;
    //private const float FARM_SUSHI_TIMER_MAX = 20f;
    private const float FARM_SUSHI_TIMER_MAX = 5f; // Debug speed


    private int _farmSushiAmount = 25;
    private bool _canFarmSushi;
    
    private void Awake()
    {
        Instance = this;
        _farmSushiTimer = FARM_SUSHI_TIMER_MAX;
    }

    private void Start()
    {
        UpdateSushiText();
        GameManager.Instance.OnGamePlayStarted += InstanceOnOnGamePlayStarted;
    }

    private void InstanceOnOnGamePlayStarted(object sender, EventArgs e)
    {
        _canFarmSushi = true;
    }

    private void Update()
    {
        if (_canFarmSushi)
        {
            FarmSushiOverTime();
        }
    }

    private void FarmSushiOverTime()
    {
        _farmSushiTimer -= Time.deltaTime;
        
        if (_farmSushiTimer <= 0)
        {
            _sushi += _farmSushiAmount;
            _farmSushiTimer = FARM_SUSHI_TIMER_MAX;
        }
        UpdateSushiText();
    }

    private void UpdateSushiText()
    {
        _sushiText.text = "SUSHI: " + _sushi;
    }

    public void SubtractSushi(int value)
    {
        _sushi -= value;
        UpdateSushiText();
    }

    public void AddSushi(int value)
    {
        _sushi += value;
        UpdateSushiText();
    }
    
    public int GetSushiAmount()
    {
        return _sushi;
    }

}
