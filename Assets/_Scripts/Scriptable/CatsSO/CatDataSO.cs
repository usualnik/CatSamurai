using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CatDataSO")]
public class CatDataSO : ScriptableObject
{
    public string CatName;
    public float CatHealth;
    public int CatPrice;
    public GameObject CatPrefab;
    public Sprite UISprite;
}
