using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryTellingManager : MonoBehaviour
{
   public static StoryTellingManager Instance { get; private set; }
   public event EventHandler OnStoryTellEnd;

   [SerializeField] private TextMeshProUGUI _storyText;
   [SerializeField] private Canvas _storyTellingCanvas;

   private int _currentSceneIndex;
   
   #region Phrases
  
   private int _dialogIndex;
   
   //Scene 1
   private readonly string[] _firstScenePhrases =  {"Держитесь, генерал! Подкрепление уже совсем близко!", "Они бросились в атаку целым лагерем!"};

   #endregion

   private void Awake()
   {
      Instance = this;
      
      _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
   }

   private void Start()
   {
      GameManager.Instance.OnGamePlayStarted += GameManager_OnGamePlayStarted;
      QuestManager.Instance.OnFirstLevelQuestAlmostComplete += QuestManager_OnFirstLevelQuestAlmostComplete;
   }



   private void OnDestroy()
   {
      GameManager.Instance.OnGamePlayStarted -= GameManager_OnGamePlayStarted;
      QuestManager.Instance.OnFirstLevelQuestAlmostComplete -= QuestManager_OnFirstLevelQuestAlmostComplete;
   }
   
   private void QuestManager_OnFirstLevelQuestAlmostComplete(object sender, EventArgs e)
   {
      TellStory();
   }

   private void GameManager_OnGamePlayStarted(object sender, EventArgs e)
   {
      TellStory();
   }

   private void Update()
   {
      if (Input.anyKeyDown && _storyTellingCanvas.gameObject.activeInHierarchy)
      {
         _storyTellingCanvas.gameObject.SetActive(false);
         OnStoryTellEnd?.Invoke(this,EventArgs.Empty);
      }
   }

   private void TellStory()
   {
      _storyTellingCanvas.gameObject.SetActive(true);
         
         switch (_currentSceneIndex)
         {
            case 0:
               // Main menu index
               break;
            case 1:
               // Choose level scene index
               break;
            case 2:
               _storyText.text = _firstScenePhrases[_dialogIndex];
               _dialogIndex++;
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
