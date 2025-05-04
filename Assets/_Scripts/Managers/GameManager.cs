using System;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event EventHandler OnGamePlayStarted;

    [Header("Pause and GameOver")]
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private GameObject _levelCompleteMenu;
    [SerializeField] private GameObject _loadingPanel;
    

    [Header("Canvases")] 
    [SerializeField] private Canvas _gameCanvas;
    [SerializeField] private Canvas _tutorialCanvas;
    [SerializeField] private Canvas _pauseCanvas;

    private Tutorial _tutorial;

    private const int MAIN_MENU_BUILD_INDEX = 0;
    private const int CHOOSE_LEVEL_SCENE_BUILD_INDEX = 1;
    private const int FIRST_LEVEL_SCENE_INDEX = 2;
    private const int LAST_LEVEL_SCENE_INDEX = 11;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More than one instance of Game Manager");
        }

        Time.timeScale = 1f;
    }

    private void Start()
    {

        if (SceneContext.Instance.GetSceneIndex() == FIRST_LEVEL_SCENE_INDEX)
        {
            _tutorial = _tutorialCanvas.GetComponent<Tutorial>();
            _tutorial.OnTutorialEnded += Tutorial_OnTutorialEnded;
        }

        UICatSetupMenu.Instance.OnCatSetupApproved += UICatSetupMenu_OnCatSetupApproved;
        GameOverZone.Instance.OnRacoonEnterGameOverZone += GameOverZone_OnRacoonEnterGameOverZone;
        
        //Quests
        QuestManager.Instance.OnFirstLevelQuestComplete += QuestManager_OnFirstLevelQuestComplete;
        QuestManager.Instance.OnSecondLevelQuestComplete += QuestManager_OnSecondLevelQuestComplete;
        QuestManager.Instance.OnThirdLevelQuestComplete += QuestManager_OnThirdLevelQuestComplete;
        QuestManager.Instance.OnFourthLevelQuestComplete += QuestManager_OnFourthLevelQuestComplete;
        QuestManager.Instance.OnFiveLevelQuestComplete += QuestManager_OnFiveLevelQuestComplete;
        QuestManager.Instance.OnSixLevelQuestComplete += QuestManager_OnSixLevelQuestComplete;
        QuestManager.Instance.OnSevenLevelQuestComplete += QuestManager_OnSevenLevelQuestComplete;
        QuestManager.Instance.OnEightLevelQuestComplete += QuestManager_OnEightLevelQuestComplete;
        QuestManager.Instance.OnNineLevelQuestComplete += QuestManager_OnNineLevelQuestComplete;
        QuestManager.Instance.OnTenLevelQuestComplete += QuestManager_OnTenLevelQuestComplete;
            
    }

    private void OnDestroy()
    {
        if (SceneContext.Instance.GetSceneIndex() == FIRST_LEVEL_SCENE_INDEX)
        {
            _tutorial.OnTutorialEnded -= Tutorial_OnTutorialEnded;
        }

        UICatSetupMenu.Instance.OnCatSetupApproved -= UICatSetupMenu_OnCatSetupApproved;
        GameOverZone.Instance.OnRacoonEnterGameOverZone -= GameOverZone_OnRacoonEnterGameOverZone;
        
        //Quests
        QuestManager.Instance.OnFirstLevelQuestComplete -= QuestManager_OnFirstLevelQuestComplete;
        QuestManager.Instance.OnSecondLevelQuestComplete -= QuestManager_OnSecondLevelQuestComplete;
        QuestManager.Instance.OnThirdLevelQuestComplete -= QuestManager_OnThirdLevelQuestComplete;
        QuestManager.Instance.OnFourthLevelQuestComplete -= QuestManager_OnFourthLevelQuestComplete;
        QuestManager.Instance.OnFiveLevelQuestComplete -= QuestManager_OnFiveLevelQuestComplete;
        QuestManager.Instance.OnSixLevelQuestComplete -= QuestManager_OnSixLevelQuestComplete;
        QuestManager.Instance.OnSevenLevelQuestComplete -= QuestManager_OnSevenLevelQuestComplete;
        QuestManager.Instance.OnEightLevelQuestComplete -= QuestManager_OnEightLevelQuestComplete;
        QuestManager.Instance.OnNineLevelQuestComplete -= QuestManager_OnNineLevelQuestComplete;
        QuestManager.Instance.OnTenLevelQuestComplete -= QuestManager_OnTenLevelQuestComplete;

    }

    #region QuestComplete

    private void QuestManager_OnFirstLevelQuestComplete(object sender, EventArgs e)
    {
        LevelComplete();
    }
    private void QuestManager_OnSecondLevelQuestComplete(object sender, EventArgs e)
    {
        LevelComplete();
    }
    
    private void QuestManager_OnThirdLevelQuestComplete(object sender, EventArgs e)
    {
        LevelComplete();
    }
    
    private void QuestManager_OnFourthLevelQuestComplete(object sender, EventArgs e)
    {
        LevelComplete();
    }

    private void QuestManager_OnFiveLevelQuestComplete(object sender, EventArgs e)
    {
        LevelComplete();
    }
    private void QuestManager_OnSixLevelQuestComplete(object sender, EventArgs e)
    {
        LevelComplete();
    }
    private void QuestManager_OnSevenLevelQuestComplete(object sender, EventArgs e)
    {
        LevelComplete();
    }
    private void QuestManager_OnEightLevelQuestComplete(object sender, EventArgs e)
    {
       LevelComplete();
    }
    
    private void QuestManager_OnNineLevelQuestComplete(object sender, EventArgs e)
    {
        LevelComplete();
    }
    
    private void QuestManager_OnTenLevelQuestComplete(object sender, EventArgs e)
    {
        LevelComplete();
    }

    #endregion
    
    #region GameOverConditions
    
    private void GameOverZone_OnRacoonEnterGameOverZone(object sender, GameOverMessageEventArgs e)
    {
        GameOver(e.GameOverMessage);
    }

    #endregion

    private void UICatSetupMenu_OnCatSetupApproved(object sender, EventArgs e)
    {
        OnGamePlayStarted?.Invoke(this, EventArgs.Empty);
    }

    private void Tutorial_OnTutorialEnded(object sender, EventArgs e)
    {
        StartGameAfterTutorial();
    }

    private void StartGameAfterTutorial()
    {
        _tutorialCanvas.gameObject.SetActive(false);
        _gameCanvas.gameObject.SetActive(true);
        
    }

    public void GamePause()
    {
        _pauseCanvas.gameObject.SetActive(true);
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        _pauseCanvas.gameObject.SetActive(false);
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void GameOver(string gameOverMessage)
    {
        Time.timeScale = 0f;
        _pauseCanvas.gameObject.SetActive(true);
        _gameOverMenu.SetActive(true);
        _gameOverText.text = gameOverMessage;
    }

    private void LevelComplete()
    {
        SaveLoad.Instance.SaveCompletedLevelIndex(SceneContext.Instance.GetSceneIndex() + 1);
        
        Time.timeScale = 0f;
        _pauseCanvas.gameObject.SetActive(true);
        _levelCompleteMenu.SetActive(true);
        
    }

    public void RestartScene()
    {
        _loadingPanel.SetActive(true);
        Addressables.LoadSceneAsync(SceneContext.Instance.GetSceneAddress(SceneContext.Instance.GetSceneIndex()), LoadSceneMode.Single, true);
    }

    public void LoadMainMenu()
    {
        _loadingPanel.SetActive(true);
        SceneManager.LoadScene(MAIN_MENU_BUILD_INDEX);
    }

    public void LoadChooseLevelScene()
    {
        _loadingPanel.SetActive(true);
       SceneManager.LoadScene(CHOOSE_LEVEL_SCENE_BUILD_INDEX);
    }

    public void LoadNextLevel()
    {
       _loadingPanel.SetActive(true);
       Addressables.LoadSceneAsync(SceneContext.Instance.GetSceneAddress(SceneContext.Instance.GetSceneIndex() + 1), LoadSceneMode.Single, true);
    }
 
}
