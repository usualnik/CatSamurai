using UnityEngine;

public class SceneContext : MonoBehaviour
{
    public static SceneContext Instance { get; private set; }
    
    [SerializeField] private int _sceneIndex;
    
    private readonly string[] _sceneAddressablePath = new[]
    {
        " ", // 0 = Main menu
        " ", // 1 = Choose Level Scene
        "Assets/Scenes/StoryMode/Scene_0_0_StoryMode.unity",
        "Assets/Scenes/StoryMode/Scene_0_1_StoryMode.unity",
        "Assets/Scenes/StoryMode/Scene_0_2_StoryMode.unity",
        "Assets/Scenes/StoryMode/Scene_0_3_StoryMode.unity",
        "Assets/Scenes/StoryMode/Scene_0_4_StoryMode.unity",
        "Assets/Scenes/StoryMode/Scene_0_5_StoryMode.unity",
        "Assets/Scenes/StoryMode/Scene_0_6_StoryMode.unity",
        "Assets/Scenes/StoryMode/Scene_0_7_StoryMode.unity",
        "Assets/Scenes/StoryMode/Scene_0_8_StoryMode.unity",
        "Assets/Scenes/StoryMode/Scene_0_9_StoryMode.unity"
        
    };
    
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
    public string GetSceneAddress(int index)
    {
        return _sceneAddressablePath[index];
    } 
}