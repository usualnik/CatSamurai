using System;
using UnityEngine;
using UnityEngine.UI;

public class CatDeathAnimation : MonoBehaviour
{
   [SerializeField] private Material burnTemplate;
   [SerializeField] private float burnDuration;
    
    private Image image;
    private Material burnInstance;
    private bool isBurning = false;
    private float burnProgress = 0f;

    private BaseCat _cat;

    private void Awake()
    {
        image = GetComponent<Image>();
        _cat = GetComponent<BaseCat>();
    }

    private void Start()
    {
      _cat.OnCatDeath += Cat_OnCatDeath;
    }

    private void Cat_OnCatDeath(object sender, EventArgs e)
    {
        StartBurn();
    }

    public void StartBurn()
    {
        burnInstance = new Material(burnTemplate);
        image.material = burnInstance;
        isBurning = true;
        burnProgress = 0f;
    }

    void Update()
    {
        if (!isBurning || burnInstance == null) return;

        burnProgress += Time.deltaTime / burnDuration;
        burnInstance.SetFloat("_BurnAmount", burnProgress);

        if (burnProgress >= 1f)
        {
            isBurning = false;
            Destroy(gameObject);
        }
    }
}
