using UnityEngine;
using Random = UnityEngine.Random;

public class RacoonsSpawner : MonoBehaviour
{
    [SerializeField] private RectTransform[] _racoonSpawnPoints;

    [SerializeField] private GameObject _racoonPrefab;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnRacoon),2f,10f);
    }
    private void SpawnRacoon()
    {
        int _spawnPos = Random.Range(0, _racoonSpawnPoints.Length);
        GameObject racoon = Instantiate(_racoonPrefab, _racoonSpawnPoints[_spawnPos]);
        racoon.layer = _racoonSpawnPoints[_spawnPos].gameObject.layer; // set racoon layer to spawn point layer
        racoon.transform.position = _racoonSpawnPoints[_spawnPos].transform.position;

    }
}
