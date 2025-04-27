using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CartSpawner : MonoBehaviour
{
   [SerializeField] private GameObject _cartPrefab;
   [SerializeField] private Transform _questTransform;
   [SerializeField] private RectTransform[] _cartSpawnPositions;


   private void Start()
   {
      GameManager.Instance.OnGamePlayStarted += GameManager_OnGamePlayStarted;
   }
   private void OnDestroy()
   {
      GameManager.Instance.OnGamePlayStarted -= GameManager_OnGamePlayStarted;
   }

   private void GameManager_OnGamePlayStarted(object sender, EventArgs e)
   {
      InvokeRepeating(nameof(SpawnCart), 1f,30f);
   }

   private void SpawnCart()
   {
      int randomSpawnPosIndex = Random.Range(0, _cartSpawnPositions.Length);
      
//      Instantiate(_cartPrefab, _cartSpawnPositions[randomSpawnPosIndex].transform.position, Quaternion.identity, _questTransform);
      Instantiate(_cartPrefab, _cartSpawnPositions[randomSpawnPosIndex].transform.position, Quaternion.identity, _cartSpawnPositions[randomSpawnPosIndex].transform);

   }
}
