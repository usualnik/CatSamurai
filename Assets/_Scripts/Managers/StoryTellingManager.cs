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
   private bool _isTellingStoryInScene;
   
   private readonly int[] _sceneIndexesToTellAStory = {1, 5, 8};
   
   #region Phrases
  
   private int _dialogIndex;
   
   //Scene 1
   
   private readonly string[] _firstScenePhrases =  {"Держитесь, генерал! Подкрепление уже совсем близко!", "Так держать! Их осталось совсем немного!"};

   #endregion

   private void Awake()
   {
      Instance = this;
      
      _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

      for (int i = 0; i < _sceneIndexesToTellAStory.Length; i++)
      {
         if (_currentSceneIndex == _sceneIndexesToTellAStory[i])
         {
            _isTellingStoryInScene = true;
         }
      }
      
   }

   private void Start()
   {
      GameManager.Instance.OnGamePlayStarted += GameManager_OnGamePlayStarted;
   }

   private void GameManager_OnGamePlayStarted(object sender, EventArgs e)
   {
      if (_isTellingStoryInScene)
      {
         TellStory();
      }
     
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
            case 1:
               _storyText.text = _firstScenePhrases[_dialogIndex];
               _dialogIndex++;
               break;
            case 2:
               break;
            case 3:
               break;
         }
         
   }

   
}
