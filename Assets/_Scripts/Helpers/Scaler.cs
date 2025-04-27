using UnityEngine;

[ExecuteAlways]
public class Scaler: MonoBehaviour
{
    public Vector2 targetSize = new Vector2(200, 200); // Нужный размер

    void Start()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.sizeDelta = targetSize;
    }
}
