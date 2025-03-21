using UnityEngine;

public class DestroyRacoonsOutOfBoundsX : MonoBehaviour
{
    private float screenWidth;

    private void Start()
    {
        screenWidth = Screen.width;
    }

    private void Update()
    {
        if (transform.position.x < 0)
        {
            Destroy(gameObject);
        }
    }
}
