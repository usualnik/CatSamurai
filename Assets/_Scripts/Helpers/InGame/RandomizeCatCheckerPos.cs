using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent] 
public class RandomizeCatCheckerPos : MonoBehaviour 
{
    private float _maxOffset = 30f; // Контролируемое смещение
    
    private void Awake()
    {
        ApplyRandomOffset();
    }

    private void ApplyRandomOffset()
    {
        float randomOffsetX = Random.Range(-_maxOffset, _maxOffset);
        Vector3 newPos = transform.localPosition + new Vector3(randomOffsetX, 0, 0);
        transform.localPosition = newPos;
    }
}