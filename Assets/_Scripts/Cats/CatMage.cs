using UnityEngine;

public class CatMage : BaseCat
{
    
    [Header("Default")]
    [SerializeField] private GameObject _mageBulletPrefab;
    [SerializeField] private Transform _spawnMageBulletPosition;
    [SerializeField] private Transform _raycastPos;
    private float _mageAttackCooldown;
    
    [Header("Second Tier")]
    [SerializeField] private GameObject _secondTierMageBulletPrefab;
    
    [Header("Third Tier")]
    [SerializeField] private GameObject _thirdTierMageBulletPrefab;

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
                _mageBulletPrefab = _secondTierMageBulletPrefab;
                break;
            case 3:
                _mageBulletPrefab = _thirdTierMageBulletPrefab;
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
        _mageAttackCooldown -= Time.deltaTime;
        if (_mageAttackCooldown <= 0)
        {
            GameObject bullet = Instantiate(_mageBulletPrefab, _spawnMageBulletPosition.position,
                Quaternion.identity, transform);

            if (bullet)
            {
                bullet.transform.Rotate(Vector3.forward, 90f); // apply rotation, just for visuals
                bullet.layer = gameObject.layer;
             
                _mageAttackCooldown = 3f;
            }

        }
    }

}
