using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _questText;
    [SerializeField] private GameObject _questWindow;

    private int _currentSceneIndex;
    private bool _isHavingQuestInScene;
    
    private readonly int[] _sceneIndexesToShowQuests = {1, 2, 3, 6};

    #region Qests
  
    //Scene 1
    private readonly string _firstSceneQuestText = "Продержитесь до прибытия подкрепления - 05:00";
    private float _reinforcementTimer = 300f; // 5 mins

    #endregion

    private void Awake()
    {
        Instance = this;
        
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        for (int i = 0; i < _sceneIndexesToShowQuests.Length; i++)
        {
            if (_currentSceneIndex == _sceneIndexesToShowQuests[i])
            {
                _isHavingQuestInScene = true;
            }
        }
    }


    private void Start()
    {
        StoryTellingManager.Instance.OnStoryTellEnd += StoryTellingManager_OnStoryTellEnd;
    }

    private void StoryTellingManager_OnStoryTellEnd(object sender, EventArgs e)
    {
        if (_isHavingQuestInScene)
        {
            ShowQuest();
        }
    }


    private void ShowQuest()
    {
        _questWindow.SetActive(true);
        switch (_currentSceneIndex)
        {
            case 1:
                _questText.text = _firstSceneQuestText;
                //Start reinforcement timer
                break;
            case 2:
                break;
        }
    }

   
}
