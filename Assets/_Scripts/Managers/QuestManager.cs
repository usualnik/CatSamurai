using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }
    
    //public event EventHandler<GameOverMessageEventArgs> OnQuestFailGameOver;
    

    [SerializeField] private TextMeshProUGUI _questText;
    [SerializeField] private GameObject _questWindow;
    [SerializeField] private TextMeshProUGUI _questTimerText;

    private int _currentSceneIndex;
    private bool _isHavingQuestInScene;
    
    private readonly int[] _sceneIndexesToShowQuests = {1, 2, 3, 6};

    #region Qests
    
    //Scene 1
    public event EventHandler OnFirstLevelQuestComplete;
    private readonly string _firstSceneQuestText = "Продержитесь до прибытия подкрепления!";
    private float _firstSceneReinforcementTimer = 180f; // 3 min 180
    private bool _firstSceneReinforcementTimerStarted;

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

    private void OnDestroy()
    {
        StoryTellingManager.Instance.OnStoryTellEnd -= StoryTellingManager_OnStoryTellEnd;
    }

    private void Update()
    {
        if (_firstSceneReinforcementTimerStarted)
        {
            _firstSceneReinforcementTimer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(_firstSceneReinforcementTimer / 60);
            int seconds = Mathf.FloorToInt(_firstSceneReinforcementTimer % 60);

            _questTimerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            if (_firstSceneReinforcementTimer <= 0)
            {
               OnFirstLevelQuestComplete?.Invoke(this,EventArgs.Empty);
            }
        }
        
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
                _firstSceneReinforcementTimerStarted = true;
                break;
            case 2:
                break;
        }
    }
    
}
