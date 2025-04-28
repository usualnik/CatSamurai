using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class UICatBars : MonoBehaviour
{
    [SerializeField] private Image _xpbar;
    [SerializeField] private Image _healthBar;
    [SerializeField] private TextMeshProUGUI _leveltext;
     
    private BaseCat _cat;
    private void Awake()
    {
        _xpbar.fillAmount = 0;
    }

    private void Start()
    {
        _cat = gameObject.GetComponent<BaseCat>();
        UpdateHealthBar();

        _cat.OnTakingDamage += Cat_OnTakingDamage;
        _cat.OnXpGained += Cat_OnXpGained;
        _cat.OnLevelUp += Cat_OnLevelUp;
        _cat.OnTakingHealing += Cat_OnTakingHealing;
    }
    private void OnDestroy()
    {
        _cat.OnTakingDamage -= Cat_OnTakingDamage;
        _cat.OnXpGained -= Cat_OnXpGained;
        _cat.OnLevelUp -= Cat_OnLevelUp;
        _cat.OnTakingHealing -= Cat_OnTakingHealing;
        
    }

    private void Cat_OnTakingHealing(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }
    private void Cat_OnTakingDamage(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }
    
    
    private void Cat_OnLevelUp(object sender, BaseCat.OnLevelUpEventArgs e)
    {
        UpdateLevelUpText(e.Level);
    }

    private void Cat_OnXpGained(object sender, BaseCat.XpGainedEventArgs e)
    {
        UpdateXpBar(e.CurrentXpGained);
    }

    private void UpdateHealthBar()
    {
       
        _healthBar.fillAmount = _cat.GetCurrentHealth() / _cat._maxCatHealth;
    }

    private void UpdateXpBar(float currentXp)
    {
        _xpbar.fillAmount = currentXp;
    }

    private void UpdateLevelUpText(int level)
    {
        if (YG2.envir.language == "ru")
        {
            _leveltext.text = "Ур." + level;

        }
        else
        {
            _leveltext.text = "Lv." + level;

        }
    }

}

