using UnityEngine;

public class SushiSupportAnim: MonoBehaviour
{
    [SerializeField] private float FlySpeed = 100f;
    private RectTransform rectTransform;
    private bool shouldAttract;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (!shouldAttract)
        {
            MoveUI(Vector2.up * FlySpeed * Time.deltaTime);
            
            if (rectTransform.anchoredPosition.y > 200f)
            {
                Destroy(gameObject);
            }
        }
        
    }

    private void MoveUI(Vector2 delta)
    {
        rectTransform.anchoredPosition += delta;
    }

}