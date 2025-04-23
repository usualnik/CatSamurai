using System.Collections;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WaitToDestroySelf());
    }

    private IEnumerator WaitToDestroySelf()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
