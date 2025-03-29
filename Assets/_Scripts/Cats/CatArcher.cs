using System;
using UnityEngine;

public class CatArcher : BaseCat
{
   
    [SerializeField] private GameObject _archerBulletPrefab;
    [SerializeField] private Transform _spawnMageBulletPosition;

    private float _archerAttackCooldown;

    protected override void DefaultAction()
    {
        _archerAttackCooldown -= Time.deltaTime;
        if (_archerAttackCooldown <= 0)
        {
            GameObject arrow = Instantiate(_archerBulletPrefab, _spawnMageBulletPosition.position, Quaternion.identity, transform);
           
            // GameObject arrow =
            //     BulletObjectPoolManager.Instance.GetPooledObject(BulletObjectPoolManager.BulletType.ArcherBullet);
            
            if (arrow)
            {
                //arrow.transform.SetParent(gameObject.transform);
                //arrow.transform.position = _spawnMageBulletPosition.transform.position;
                //arrow.transform.rotation = gameObject.transform.rotation;
                arrow.layer = gameObject.layer;
               // arrow.SetActive(true);
                _archerAttackCooldown = 1.5f;
            }
        }
    }
    protected override void SecondTierAction()
    {
       
    }

    protected override void ThirdTierAction()
    {
        Debug.Log("Third Tier action");
    }

}

    
