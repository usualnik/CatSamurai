using System;
using TMPro;
using UnityEngine;
using YG;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI _questText;
    [SerializeField] private GameObject _questWindow;
    [SerializeField] private TextMeshProUGUI _questTimerText;

    private int _currentSceneIndex;
    
    #region Qests

    #region FirstScene

    //Level 1
    public event EventHandler OnFirstLevelQuestComplete;
    public event EventHandler OnFirstLevelQuestAlmostComplete;
    private string _firstSceneQuestText;
    private float _firstSceneReinforcementTimer = 90f; // 1.5 min 
    private bool _firstSceneReinforcementTimerStarted;
    private bool _firstSceneTimerWarning = true;

    #endregion
    
    #region SecondScene

    //Level 2
    public event EventHandler OnSecondLevelQuestComplete;
    
    private string _secondSceneQuestText;
    private const int _secondSceneSushiAmountObjective = 500;
    
    #endregion
    
    #region ThirdScene

    //Level 3
    public event EventHandler OnThirdLevelQuestComplete;
    
    private string _thirdSceneQuestText;
    
    #endregion
  
    #region FourthScene

    //Level 4
    public event EventHandler OnFourthLevelQuestComplete;
    private string _fourthSceneQuestText;
    
    #endregion
    
    #region FifthScene

    //Level 5
    public event EventHandler OnFiveLevelQuestComplete;

    private string _fifthSceneQuestText;
    
    #endregion
    
    #region SixthScene

    //Level 6
    public event EventHandler OnSixLevelQuestComplete;
    //public event EventHandler OnSecondLevelQuestAlmostComplete;
    
    private string _sixthSceneQuestText;
    
    #endregion
    
    #region SeventhScene

    //Level 7
    public event EventHandler OnSevenLevelQuestComplete;
    //public event EventHandler OnSecondLevelQuestAlmostComplete;
    
    private string _seventhSceneQuestText;
    
    #endregion
    
    #region EightScene

    //Level 8
    public event EventHandler OnEightLevelQuestComplete;
    //public event EventHandler OnSecondLevelQuestAlmostComplete;
    
    private string _eightSceneQuestText;
    
    #endregion
    
    #region NineScene

    //Level 9
    public event EventHandler OnNineLevelQuestComplete;
    //public event EventHandler OnSecondLevelQuestAlmostComplete;
    
    private string _nineSceneQuestText;
    
    #endregion
    
    #region TenScene

    //Level 10
    public event EventHandler OnTenLevelQuestComplete;
    //public event EventHandler OnSecondLevelQuestAlmostComplete;
    
    private string _tenSceneQuestText;
    
    #endregion
    
    #endregion    

    private void Awake()
    {
        Instance = this;      
    }

    private void Start()
    {
        StoryTellingManager.Instance.OnStoryTellEnd += StoryTellingManager_OnStoryTellEnd;
        
        
        //Translation
        if (YG2.envir.language == "ru")
        {
             _firstSceneQuestText = "Продержитесь до прибытия подкрепления и отбейте атаку!";
             _secondSceneQuestText = "Накопите 500 ед. суши и отбейте атаку!";
             _thirdSceneQuestText = "Защитите мирных жителей";
             _fourthSceneQuestText = "Убейте главарей енотов";
             _fifthSceneQuestText = "Очистите ваши земли от енотов";
             _sixthSceneQuestText = "Вернитесь в замок, добивая остатки врагов";
             _seventhSceneQuestText = "Защищайте лекарей, пока они не закончат свой ритуал";
             _eightSceneQuestText = "Помогите разбойникам";
             _nineSceneQuestText = "Выберитесь из леса";
             _tenSceneQuestText = "Захватите разведчика";
        }
        else
        {
            _firstSceneQuestText = "Hold out until reinforcements arrive and repel the attack!";
            _secondSceneQuestText = "Accumulate 500 sushi and fight off the attack!";
            _thirdSceneQuestText = "Protect civilians";
            _fourthSceneQuestText = "Kill the raccoon leaders";
            _fifthSceneQuestText = "Clear your lands of raccoons";
            _sixthSceneQuestText = "Return to the castle, finishing off the remaining enemies";
            _seventhSceneQuestText = "Protect the healers until they finish their ritual.";
            _eightSceneQuestText = "Help the robbers";
            _nineSceneQuestText = "Get out of the forest";
            _tenSceneQuestText = "Capture the scout";
        }
        
         
        
    }

    private void OnDestroy()
    {
        StoryTellingManager.Instance.OnStoryTellEnd -= StoryTellingManager_OnStoryTellEnd;
    }

    #region FirstSceneBehaviour

    private void FirstLevelQuest()
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

    #region SecondSceneBehaviour

    private void SecondLevelQuest()
    {
        if (SushiManager.Instance.GetSushiAmount() > _secondSceneSushiAmountObjective)
        {
            if (RacoonsSpawnManager.Instance.GetRacoonsLeftAmount() <= 0)
            {
                OnSecondLevelQuestComplete?.Invoke(this,EventArgs.Empty);
            }
        }
    }
    
    #endregion
    
    #region ThirdSceneBehaviour

    private void ThirdLevelQuest()
    {
       if (RacoonsSpawnManager.Instance.GetRacoonsLeftAmount() <= 0)
       {
           OnThirdLevelQuestComplete?.Invoke(this,EventArgs.Empty);
       }
    }
    
    #endregion

    #region FourthSceneBehaviour

    private void FourthLevelQuest()
    {
        if (RacoonsSpawnManager.Instance.GetRacoonsLeftAmount() <= 0)
        {
          OnFourthLevelQuestComplete?.Invoke(this, EventArgs.Empty);
        }
    }
    
    #endregion
    
    #region FiveSceneBehaviour

    private void FiveLevelQuest()
    {
        if (RacoonsSpawnManager.Instance.GetRacoonsLeftAmount() <= 0)
        {
            OnFiveLevelQuestComplete?.Invoke(this,EventArgs.Empty);
        }
    }
    
    #endregion
    
    #region SixSceneBehaviour

    private void SixLevelQuest()
    {
        if (RacoonsSpawnManager.Instance.GetRacoonsLeftAmount() <= 0)
        {
            OnSixLevelQuestComplete?.Invoke(this,EventArgs.Empty);
        }
    }
    
    #endregion
    
    #region SevenSceneBehaviour

    private void SevenLevelQuest()
    {
        if (RacoonsSpawnManager.Instance.GetRacoonsLeftAmount() <= 0)
        {
            OnSevenLevelQuestComplete?.Invoke(this, EventArgs.Empty);
        }
    }
    
    #endregion
    
    #region EightSceneBehaviour

    private void EightLevelQuest()
    {
        if (RacoonsSpawnManager.Instance.GetRacoonsLeftAmount() <= 0)
        {
           OnEightLevelQuestComplete?.Invoke(this, EventArgs.Empty);
        }
    }
    
    #endregion
    
    #region NineSceneBehaviour

    private void NineLevelQuest()
    {
        if (RacoonsSpawnManager.Instance.GetRacoonsLeftAmount() <= 0)
        {
            OnNineLevelQuestComplete?.Invoke(this, EventArgs.Empty);
        }
    }
    
    #endregion
    
    #region TenSceneBehaviour

    private void TenLevelQuest()
    {
        if (RacoonsSpawnManager.Instance.GetRacoonsLeftAmount() <= 0)
        {
            OnTenLevelQuestComplete?.Invoke(this, EventArgs.Empty);
        }
    }
    
    #endregion
    
    private void Update()
    {
        _currentSceneIndex = SceneContext.Instance.GetSceneIndex();
        switch (_currentSceneIndex)
        {
            case 0:
                // Main menu index
                break;
            case 1:
                // Choose level scene index
                break;
            case 2:
                FirstLevelQuest();
                break;
            case 3:
                SecondLevelQuest();
                break;
            case 4:
                ThirdLevelQuest();
                break;
            case 5:
                FourthLevelQuest();
                break;
            case 6:
                FiveLevelQuest();
                break;
            case 7:
                SixLevelQuest();
                break;
            case 8:
                SevenLevelQuest();
                break;
            case 9:
                EightLevelQuest();
                break;
            case 10:
                NineLevelQuest();
                break;
            case 11:
                TenLevelQuest();
                break;
        }

    }
    
    private void StoryTellingManager_OnStoryTellEnd(object sender, EventArgs e)
    {
        ShowQuest();
    }

    private void ShowQuest()
    {
        _currentSceneIndex = SceneContext.Instance.GetSceneIndex();
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
                _questText.text = _secondSceneQuestText;
                break;
            case 4:
                _questText.text = _thirdSceneQuestText;
                break;
            case 5:
                _questText.text = _fourthSceneQuestText;
                break;
            case 6:
                _questText.text = _fifthSceneQuestText;
                break;
            case 7:
                _questText.text = _sixthSceneQuestText;
                break;
            case 8:
                _questText.text = _seventhSceneQuestText;
                break;
            case 9:
                _questText.text = _eightSceneQuestText;
                break;
            case 10:
                _questText.text = _nineSceneQuestText;
                break;
            case 11:
                _questText.text = _tenSceneQuestText;
                break;

        }
    }
    
}
