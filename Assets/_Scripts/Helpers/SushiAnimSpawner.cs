using Unity.Mathematics;
using UnityEngine;

public class SushiAnimSpawner : MonoBehaviour
{
    public static SushiAnimSpawner Instance;
    
    [SerializeField] public RectTransform _sushiTextPos;
    [SerializeField] private GameObject _sushiOverTimePrefab;
    [SerializeField] private GameObject _sushiSupportPrefab;


    private Vector3 _sushiTextPosOffset = new Vector3(-500f,100f,0);

    private void Awake()
    {
        Instance = this;
    }


    public void FarmSushiOverTimeAnimation()
    {
         Instantiate(_sushiOverTimePrefab, _sushiTextPos.position + _sushiTextPosOffset, quaternion.identity, _sushiTextPos);
    }

    public void SupportSushiFarm(Transform spawnPos)
    {
        Instantiate(_sushiSupportPrefab, spawnPos.position, quaternion.identity, spawnPos);
    }
}