using UnityEngine;

public class CatArcher : BaseCat
{
    [SerializeField] private GameObject _archerBulletPrefab;
    [SerializeField] private Transform _spawnMageBulletPosition;

    private float _archerAttackCooldown;

    protected override void PerformAction()
    {
        _archerAttackCooldown -= Time.deltaTime;
        if (_archerAttackCooldown <= 0)
        {
            Instantiate(_archerBulletPrefab, _spawnMageBulletPosition.position, Quaternion.identity, transform);
            _archerAttackCooldown = 1.5f;
        }
    }
}

    
