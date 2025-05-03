using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private UIChooseLevelIcon[] _levelIcons;

    private const int BUILD_INDEX_OFFSET = 2; // skips main menu and scene loader
    private const int MAIN_MENU_BUILD_INDEX = 0;

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

    private void Start()
    {
        foreach (var icon in _levelIcons)
        {
            icon.OnClick += UIChooseLevelIcon_OnClick;
        }
    }

    private void OnDestroy()
    {
        foreach (var icon in _levelIcons)
        {
            icon.OnClick -= UIChooseLevelIcon_OnClick;
        }
    }

    private void UIChooseLevelIcon_OnClick(object sender, UIChooseLevelIcon.UIChooseLevelIconEventArgs e)
    {
        LoadScene(e.Index);
    }

    private void LoadScene(int sceneBuildIndex)
    {
        //SceneManager.LoadScene(sceneBuildIndex);
       Addressables.LoadSceneAsync(_sceneAddressablePath[sceneBuildIndex], LoadSceneMode.Single, true);
    }




    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_BUILD_INDEX);
    }
    
    
}
