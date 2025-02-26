using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RacoonsSpawner : MonoBehaviour
{
    [SerializeField] private RectTransform[] _racoonSpawnPoints;

    [SerializeField] private GameObject _racoonPrefab;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnRacoon),2f,5f);
    }
    private void SpawnRacoon()
    {
        int _spawnPos = Random.Range(0, _racoonSpawnPoints.Length);
        Instantiate(_racoonPrefab, _racoonSpawnPoints[_spawnPos]);
        transform.parent = null;
    }
}
