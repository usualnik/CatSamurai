using UnityEngine;

public class BulletPrefabMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * Vector3.right;
    }
}
