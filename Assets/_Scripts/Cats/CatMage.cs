using UnityEngine;

public class CatMage : BaseCat
{
    
    [Header("Default")]
    [SerializeField] private GameObject _mageBulletPrefab;
    [SerializeField] private Transform _spawnMageBulletPosition;
    [SerializeField] private Transform _raycastPos;
    private float _mageAttackCooldownTimer;
    private const float MAGE_ATTACK_COOLDOWN_TIMER_MAX = 3f;
    
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
        _mageAttackCooldownTimer -= Time.deltaTime;
        if (_mageAttackCooldownTimer <= 0)
        {
            GameObject bullet = Instantiate(_mageBulletPrefab, _spawnMageBulletPosition.position,
                Quaternion.identity, transform);

            if (bullet)
            {
                bullet.transform.Rotate(Vector3.forward, 90f); // apply rotation, just for visuals
                bullet.layer = gameObject.layer;
                _mageAttackCooldownTimer = MAGE_ATTACK_COOLDOWN_TIMER_MAX;
            }

        }
    }

}
