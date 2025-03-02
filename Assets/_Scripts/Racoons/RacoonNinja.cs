using System;
using UnityEngine;

public class RacoonNinja : BaseRacoon
{
    [SerializeField] private int _racoonNinjaHealth = 100;
    
    public override void TakeDamage(int damage)
    {
        _racoonNinjaHealth -= damage;
        if (_racoonNinjaHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
   
}
