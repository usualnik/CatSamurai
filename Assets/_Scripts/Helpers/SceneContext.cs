using UnityEngine;

public class SceneContext : MonoBehaviour
{
    public static SceneContext Instance { get; private set; }

    [SerializeField] private int _sceneIndex;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public int GetSceneIndex()
    {
        return _sceneIndex;
    } 
}