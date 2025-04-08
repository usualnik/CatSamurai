using System;
using System.Collections;
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
   
   //Scene 2
   private readonly string[] _secondScenePhrases =  {"В прошлом бою мы израсходовали все запасы суши! Пополните запасы, как можно скорее!"};
   
   //Scene 3
   private readonly string[] _thirdScenePhrases =  {"Мирные жители в ужасе бегут в замок! Защищайте их!"};
   
   //Scene 4
   private readonly string[] _fourthScenePhrases =  {"Твои жалкие попытки спасти эти земли ничего не решат, ваш конец уже близок!"};
   
   //Scene 5
   private readonly string[] _fifthScenePhrases =  {"Уничтожте остатки ненавистных енотов, эта земля с роду принадлежала котам-самураям!"};
   
   //Scene 6
   private readonly string[] _sixthScenePhrases =  {"Мы хорошо постарались, генерал, дома нас ждут первоклассные суши"};
   
   //Scene 7
   private readonly string[] _seventhScenePhrases =  {"Вам повезло, что вы остались в живых. Один из ваших самураев тащил вас через бамбуковые заросли более часа, он заслужил хорошие суши."};
   
   //Scene 8
   private readonly string[] _eighthScenePhrases =  {"Еще вчера мы бы просто ограбили тебя и оставили умирать, но сегодня мы готовы присоедениться, за добротную порцию суши."};
   
   //Scene 9
   private readonly string[] _nineScenePhrases =  {"Наши войны восстановили силы, пора выбираться отсюда"};
   
   //Scene 10
   private readonly string[] _tenScenePhrases =  {"Генерал, все соседние поселения в огне. Мы должны схватить одного из енотов и допросить."};

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

      StartCoroutine(WaitToTellStory());
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
            case 3:
               _storyText.text = _secondScenePhrases[_dialogIndex];
               _dialogIndex++;
               break;
            case 4:
               _storyText.text = _thirdScenePhrases[_dialogIndex];
               _dialogIndex++;
               break;
            case 5:
               _storyText.text = _fourthScenePhrases[_dialogIndex];
               _dialogIndex++;
               break;
            case 6:
               _storyText.text = _fifthScenePhrases[_dialogIndex];
               _dialogIndex++;
               break;
            case 7:
               _storyText.text = _sixthScenePhrases[_dialogIndex];
               _dialogIndex++;
               break;
            case 8:
               _storyText.text = _seventhScenePhrases[_dialogIndex];
               _dialogIndex++;
               break;
            case 9:
               _storyText.text = _eighthScenePhrases[_dialogIndex];
               _dialogIndex++;
               break;
            case 10:
               _storyText.text = _nineScenePhrases[_dialogIndex];
               _dialogIndex++;
               break;
            case 11:
               _storyText.text = _tenScenePhrases[_dialogIndex];
               _dialogIndex++;
               break;
         }
         
   }

   private IEnumerator WaitToTellStory()
   {
      yield return new WaitForSeconds(1.5f);
      TellStory();
   }
}
