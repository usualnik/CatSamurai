using System;
using UnityEngine;

public class CatChecker : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<BaseCat>())
        {
            Debug.Log("Collision with cat");
        }
    }
}
