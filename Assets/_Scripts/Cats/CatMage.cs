using UnityEngine;

public class CatMage : BaseCat
{
    [SerializeField] private int _mageCatHealth = 100;

    [SerializeField] private GameObject _mageBulletPrefab;
    
    [SerializeField] private Transform _spawnMageBulletPosition;
    
    private float _mageAttackCooldown;

    protected override void PerformAction()
    {
        _mageAttackCooldown -= Time.deltaTime;
        if (_mageAttackCooldown <= 0)
        {
            //GameObject bullet = Instantiate(_mageBulletPrefab, _spawnMageBulletPosition.position, Quaternion.identity, transform);
            
            GameObject bullet = BulletObjectPoolManager.Instance.GetPooledObject(BulletObjectPoolManager.BulletType.MageBullet);
            
            if (bullet)
            {
                bullet.transform.SetParent(gameObject.transform);
                bullet.transform.position = _spawnMageBulletPosition.transform.position;
                bullet.transform.rotation = gameObject.transform.rotation;
                
                bullet.transform.Rotate(Vector3.forward, 90f); // apply rotation, just for visuals
                bullet.layer = gameObject.layer;
                
                bullet.SetActive(true);
                
                _mageAttackCooldown = 3f;
            }
            
        }
    }

    public override void TakeDamage(int damage)
    {
        _mageCatHealth -= damage;
        if (_mageCatHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
