using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CatDataSO")]
public class CatDataSO : ScriptableObject
{
    public string CatName;
    public int CatPrice;
    public float CatDamage;
    

    public GameObject CatPrefab;
    public Sprite UISprite;
}
