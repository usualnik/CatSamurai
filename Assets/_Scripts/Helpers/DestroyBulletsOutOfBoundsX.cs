using UnityEngine;

public class DestroyBulletsOutOfBoundsX : MonoBehaviour
{
    private float screenWidth;

    private void Start()
    {
        screenWidth = Screen.width;
    }

    private void Update()
    {
        if (transform.position.x > screenWidth)
        {
            Destroy(gameObject);
            //BulletObjectPoolManager.Instance.ReturnToPool(gameObject);
        }
    }
}
