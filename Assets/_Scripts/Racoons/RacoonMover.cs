using UnityEngine;

public class RacoonMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _isCanMove = true;
    private void Update()
    {
        if (_isCanMove)
        {
            transform.position -= _speed * Time.deltaTime * Vector3.right;
         
        }
    }

    public void CanMove(bool isCanMove)
    {
        _isCanMove = isCanMove;
    }
}
