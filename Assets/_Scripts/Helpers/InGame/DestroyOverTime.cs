using System.Collections;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] private float _destroySelfTime;

    private void Start()
    {
        StartCoroutine(WaitToDestroySelf());
    }

    private IEnumerator WaitToDestroySelf()
    {
        yield return new WaitForSeconds(_destroySelfTime);
        Destroy(gameObject);
    }
}
