using System;
using UnityEngine;

public class DealDamageToRacoon : MonoBehaviour
{
    [SerializeField] private int _bulletDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out BaseRacoon baseRacoon))
        {
            if (baseRacoon.gameObject.layer == gameObject.layer) 
            {
                baseRacoon.TakeDamage(_bulletDamage);
                Destroy(gameObject);
            }
        }
    }
}
