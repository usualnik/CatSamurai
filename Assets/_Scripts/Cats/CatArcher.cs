using UnityEngine;

public class CatArcher : BaseCat
{
   
    [SerializeField] private GameObject _archerBulletPrefab;
    [SerializeField] private GameObject _secondTierArcherBulletPrefab;
    [SerializeField] private GameObject _thirdTierArcherBulletPrefab;
    
    [SerializeField] private Transform _spawnMageBulletPosition;

    private float _archerAttackCooldown;

    private void Start()
    {
        OnLevelUp += BaseCat_OnLevelUp;
    }

    private void OnDestroy()
    {
        OnLevelUp -= BaseCat_OnLevelUp;
    }

    private void BaseCat_OnLevelUp(object sender, OnLevelUpEventArgs e)
    {
        switch (e.Level)
        {
            case 2:
                _archerBulletPrefab = _secondTierArcherBulletPrefab;
                break;
            case 3:
                _archerBulletPrefab = _thirdTierArcherBulletPrefab;
                break;
        }
    }

    protected override void DefaultAction()
    {
       Attack();
    }
    protected override void SecondTierAction()
    {
        Attack();
    }

    protected override void ThirdTierAction()
    {
        Attack();
    }

    private void Attack()
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

}

    
