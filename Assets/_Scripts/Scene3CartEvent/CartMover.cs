using UnityEngine;

public class CartMover : MonoBehaviour
{
    private float _speed = 30f;

    private void Update()
    {
        transform.position -= _speed * Time.deltaTime * Vector3.right;
    }
}

    
