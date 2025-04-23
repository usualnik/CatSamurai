using UnityEngine;

public class SushiOverTimeAnim : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 100f;
    [SerializeField] private float attractSpeed = 200f;
    [SerializeField] private float destroyDistance = 10f;

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
            MoveUI(Vector2.down * fallSpeed * Time.deltaTime);
            
            if (rectTransform.anchoredPosition.y < -120f)
            {
                shouldAttract = true;
            }
        }
        else
        {
         
            Vector2 targetPos = SushiAnimSpawner.Instance._sushiTextPos.anchoredPosition;
            Vector2 direction = (targetPos - rectTransform.anchoredPosition).normalized;
            MoveUI(direction * attractSpeed * Time.deltaTime);
            
            if (Vector2.Distance(rectTransform.anchoredPosition, targetPos) < destroyDistance)
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
