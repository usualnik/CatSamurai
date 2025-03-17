using System;
using TMPro;
using UnityEngine;

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
    public event EventHandler OnGameActive;
    public event EventHandler OnGamePlayStarted;
    public int Sushi { get; private set; } = 10000;
    
    [SerializeField] private TextMeshProUGUI _sushiText;

    [Header("Canvases")] 
    [SerializeField] private Canvas _gameCanvas;
    [SerializeField] private Canvas _tutorialCanvas;

    private Tutorial _tutorial;
    

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
    }
    
    private void Start()
    {
        _sushiText.text = "SUSHI: " + Sushi;
        _tutorial = _tutorialCanvas.GetComponent<Tutorial>();
        _tutorial.OnTutorialEnded += Tutorial_OnTutorialEnded;
        UICatSetupMenu.Instance.OnCatSetupApproved += UICatSetupMenu_OnCatSetupApproved;
    }

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
        OnGameActive.Invoke(this,EventArgs.Empty);
    }

    public void SubtractSushi(int value)
    {
        Sushi -= value;
        _sushiText.text = "SUSHI: " + Sushi;
    }

    private void GamePause()
    {
        Time.timeScale = 0f;
    }

    private void GameActive()
    {
        Time.timeScale = 1f;
    }

}
