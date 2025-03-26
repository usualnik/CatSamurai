using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI _questText;
    [SerializeField] private GameObject _questWindow;
    [SerializeField] private TextMeshProUGUI _questTimerText;

    private int _currentSceneIndex;
    #region Qests

    #region FirstScene

    //Scene 1
    public event EventHandler OnFirstLevelQuestComplete;
    public event EventHandler OnFirstLevelQuestAlmostComplete;
    private readonly string _firstSceneQuestText = "Продержитесь до прибытия подкрепления!";
    private float _firstSceneReinforcementTimer = 90f; // 1.5 min 
    private bool _firstSceneReinforcementTimerStarted;
    private bool _firstSceneTimerWarning = true;

    #endregion
  

    #endregion

    private void Awake()
    {
        Instance = this;
        
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    }

    private void Start()
    {
        StoryTellingManager.Instance.OnStoryTellEnd += StoryTellingManager_OnStoryTellEnd;
    }

    private void OnDestroy()
    {
        StoryTellingManager.Instance.OnStoryTellEnd -= StoryTellingManager_OnStoryTellEnd;
    }


    #region FirstScene

    private void FirstSceneTimer()
    {
        if (_firstSceneReinforcementTimerStarted)
        {
            _firstSceneReinforcementTimer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(_firstSceneReinforcementTimer / 60);
            int seconds = Mathf.FloorToInt(_firstSceneReinforcementTimer % 60);

            _questTimerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (_firstSceneReinforcementTimer <= 40 && _firstSceneTimerWarning)
            {
                OnFirstLevelQuestAlmostComplete?.Invoke(this,EventArgs.Empty);
                _firstSceneTimerWarning = false;
            }
            
            if (_firstSceneReinforcementTimer <= 0)
            {
                _questTimerText.text = "0:00";
                
                if (RacoonsSpawnManager.Instance.GetRacoonsLeftAmount() <= 0)
                {
                    OnFirstLevelQuestComplete?.Invoke(this,EventArgs.Empty);
                }
                
            }
        }
    }

    #endregion
    

    private void Update()
    {
        FirstSceneTimer();
    }
    
    
 
    private void StoryTellingManager_OnStoryTellEnd(object sender, EventArgs e)
    {
        ShowQuest();
    }

    private void ShowQuest()
    {
        _questWindow.SetActive(true);
        switch (_currentSceneIndex)
        {
            case 0:
                // Main menu index
                break;
            case 1:
                // Choose level scene index
                break;
            case 2:
                _questText.text = _firstSceneQuestText;
                _firstSceneReinforcementTimerStarted = true;
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            
        }
    }
    
}
