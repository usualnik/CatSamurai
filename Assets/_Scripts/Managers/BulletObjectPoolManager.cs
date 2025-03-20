using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPoolManager : MonoBehaviour
{
    public static BulletObjectPoolManager Instance { get; private set; }

    public enum BulletType
    {
        None,
        MageBullet,
        ArcherBullet
    }

    [Header("Mage Bullets")]
    [SerializeField] private GameObject mageBulletPrefab;
    [SerializeField] private int mageBulletsAmountToPool;
    private List<GameObject> _mageBulletsPool;
   
    [Header("Archer Bullets")]
    [SerializeField] private GameObject archerBulletPrefab;
    [SerializeField] private int archerBulletsAmountToPool;
    private List<GameObject> _archerBulletsPool;
    

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InitializeMageBulletsPool();
        InitializeArcherBulletsPool();
    }
    
    public GameObject GetPooledObject(BulletType bulletType)
    {
        switch (bulletType)
        {
            case BulletType.MageBullet: 
                return GetMagePooledBullet();
            case BulletType.ArcherBullet:
                return GetArcherPooledBullet();
        }
        
        return null;
    }

    public void ReturnToPool(GameObject gameObject)
    {
        gameObject.transform.SetParent(null);
        gameObject.SetActive(false);
    }

    #region Initialization

    private void InitializeMageBulletsPool()
    {
        _mageBulletsPool = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < mageBulletsAmountToPool; i++)
        {
            tmp = Instantiate(mageBulletPrefab);
            tmp.SetActive(false);
            _mageBulletsPool.Add(tmp);
        }
    }
    private void InitializeArcherBulletsPool()
    {
        _archerBulletsPool = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < archerBulletsAmountToPool; i++)
        {
            tmp = Instantiate(archerBulletPrefab);
            tmp.SetActive(false);
            _archerBulletsPool.Add(tmp);
        }
    }

    #endregion

    #region Pools

    private GameObject GetMagePooledBullet()
    {
        for(int i = 0; i < mageBulletsAmountToPool; i++)
        {
            if(!_mageBulletsPool[i].activeInHierarchy)
            {
                return _mageBulletsPool[i];
            }
        }
        
        // if we didnt find any object to pool, re-initialize objects to pool
        
        InitializeMageBulletsPool();

        return null;
    }
    private GameObject GetArcherPooledBullet()
    {
        for(int i = 0; i < archerBulletsAmountToPool; i++)
        {
            if(!_archerBulletsPool[i].activeInHierarchy)
            {
                return _archerBulletsPool[i];
            }
        }
        
        // if we didnt find any object to pool, re-initialize objects to pool
        
        InitializeArcherBulletsPool();

        return null;
    }

    #endregion




  
    
    
    
    
}

