using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    }

    private void Cat_OnLevelUp(object sender, BaseCat.OnLevelUpEventArgs e)
    {
        UpdateLevelUpText(e.Level);
    }

    private void Cat_OnXpGained(object sender, BaseCat.XpGainedEventArgs e)
    {
        UpdateXpBar(e.CurrentXpGained);
    }

    private void OnDestroy()
    {
        _cat.OnTakingDamage -= Cat_OnTakingDamage;
        _cat.OnXpGained -= Cat_OnXpGained;
    }
 
    private void Cat_OnTakingDamage(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        _healthBar.fillAmount = GetComponent<BaseCat>()._currentCatHealth / GetComponent<BaseCat>()._maxCatHealth;
    }

    private void UpdateXpBar(float currentXp)
    {
        _xpbar.fillAmount = currentXp;
    }

    private void UpdateLevelUpText(int level)
    {
        _leveltext.text = "Ур." + level;
    }


   
}

