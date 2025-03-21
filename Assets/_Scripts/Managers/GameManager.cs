using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameState
    {
        Pause,
        GameActive,
        GamePlayStarted,
        GameOver
    }
    public GameState State { get; private set; } = GameState.Pause;
    public event EventHandler OnGamePlayStarted;
    public int Sushi { get; private set; } = 1000;
    
    [SerializeField] private TextMeshProUGUI _sushiText;
    
    [Header("Pause and GameOver")]
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private GameObject _levelCompleteMenu;
    

    
    [Header("Canvases")] 
    [SerializeField] private Canvas _gameCanvas;
    [SerializeField] private Canvas _tutorialCanvas;
    [SerializeField] private Canvas _pauseCanvas;

    private Tutorial _tutorial;

    private const int MAIN_MENU_BUILD_INDEX = 0;
    //private const int CHOOSE_LEVEL_SCENE_BUILD_INDEX = 1;
    
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
        _sushiText.text = "SUSHI: " + Sushi;
        _tutorial = _tutorialCanvas.GetComponent<Tutorial>();
        _tutorial.OnTutorialEnded += Tutorial_OnTutorialEnded;
        UICatSetupMenu.Instance.OnCatSetupApproved += UICatSetupMenu_OnCatSetupApproved;
        GameOverZone.Instance.OnRacoonEnterGameOverZone += GameOverZone_OnRacoonEnterGameOverZone;
        
        QuestManager.Instance.OnFirstLevelQuestComplete += QuestManager_OnFirstLevelQuestComplete;
        

    }

    private void QuestManager_OnFirstLevelQuestComplete(object sender, EventArgs e)
    {
        LevelComplete();
    }


    #region GameOverConditions
    
    private void GameOverZone_OnRacoonEnterGameOverZone(object sender, GameOverMessageEventArgs e)
    {
        GameOver(e.GameOverMessage);
    }

    #endregion

  
    private void UICatSetupMenu_OnCatSetupApproved(object sender, EventArgs e)
    {
        State = GameState.GamePlayStarted;
        OnGamePlayStarted?.Invoke(this, EventArgs.Empty);
    }


    private void Tutorial_OnTutorialEnded(object sender, EventArgs e)
    {
        StartGameAfterTutorial();
    }

    private void StartGameAfterTutorial()
    {
        State = GameState.GameActive;
        _tutorialCanvas.gameObject.SetActive(false);
        _gameCanvas.gameObject.SetActive(true);
        
    }

    public void SubtractSushi(int value)
    {
        Sushi -= value;
        _sushiText.text = "SUSHI: " + Sushi;
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
        Time.timeScale = 0f;
        _pauseCanvas.gameObject.SetActive(true);
        _levelCompleteMenu.SetActive(true);
        
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_BUILD_INDEX);
    }

    public void LoadChooseLevelScene()
    {
       // SceneManager.LoadScene(CHOOSE_LEVEL_SCENE_BUILD_INDEX);
       Debug.Log("ChooseLevelSceneLoaded");
    }
    
}
