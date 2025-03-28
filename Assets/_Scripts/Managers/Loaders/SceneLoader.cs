using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private UIChooseLevelIcon[] _levelIcons;

    private const int BUILD_INDEX_OFFSET = 2; // skips main menu and scene loader
    private const int MAIN_MENU_BUILD_INDEX = 0;

    private void OnEnable()
    {
        foreach (var icon in _levelIcons)
        {
            icon.OnClick += UIChooseLevelIcon_OnClick;
        }
    }

    private void OnDisable()
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
        SceneManager.LoadScene(sceneBuildIndex + BUILD_INDEX_OFFSET);
    }


    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene(MAIN_MENU_BUILD_INDEX);
    }
    
    
}
