using System;
using System.Collections;
using TMPro;
using UnityEngine;
using YG;

public class SushiManager : MonoBehaviour
{
    public static SushiManager Instance { get; private set; }
     
    [SerializeField] private int _sushi;    
    [SerializeField] private TextMeshProUGUI _sushiText;

    private float _farmSushiTimer;
    private const float FARM_SUSHI_TIMER_MAX = 20f;
    //private const float FARM_SUSHI_TIMER_MAX = 5f; // Debug speed


    private int _farmSushiAmount = 25;
    private bool _canFarmSushi;
    private SushiAnimSpawner _sushiAnimSpawner;
    
    private void Awake()
    {
        Instance = this;
        _farmSushiTimer = FARM_SUSHI_TIMER_MAX;
        _sushiAnimSpawner = GetComponent<SushiAnimSpawner>();
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
            _sushiAnimSpawner.FarmSushiOverTimeAnimation();
            StartCoroutine(WaitForSushiAnimation());
            _farmSushiTimer = FARM_SUSHI_TIMER_MAX;
        }
        
    }

    private IEnumerator WaitForSushiAnimation()
    {
        yield return new WaitForSeconds(5f);
        
        if (SFX.Instance != null)
        {
            SFX.Instance.PlayAddSushiSound();
        }
        _sushi += _farmSushiAmount;
        UpdateSushiText();
    }

    private void UpdateSushiText()
    {
        if (YG2.envir.language == "ru")
        {
            _sushiText.text = "СУШИ: " + _sushi;
        }
        else
        {
            _sushiText.text = "SUSHI: " + _sushi;
        }
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
