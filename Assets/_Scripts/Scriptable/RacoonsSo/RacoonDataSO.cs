using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/RacoonDataSO")]
public class RacoonDataSO : ScriptableObject
{
    public string RacoonName;
    public float RacoonHealth;
    public GameObject RacoonPrefab;
    
}
