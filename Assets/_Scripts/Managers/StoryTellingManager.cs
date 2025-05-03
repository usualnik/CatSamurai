using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

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
   private readonly string[] _firstSceneRUPhrases =  {"Держитесь, генерал! Подкрепление уже совсем близко!", "Они бросились в атаку целым лагерем!"};
   private readonly string[] _firstSceneENPhrases =  {"Hold on, General! Reinforcements are just around the corner!", "They rushed into the attack with the whole camp!"};
   
   //Scene 2
   private readonly string[] _secondSceneRUPhrases =  {"В прошлом бою мы израсходовали все запасы суши! Пополните запасы, как можно скорее!"};
   private readonly string[] _secondSceneENPhrases =  {"We used up all our sushi supplies in the last battle! Replenish your supplies as soon as possible!"};
   
   //Scene 3
   private readonly string[] _thirdSceneRUPhrases =  {"Мирные жители в ужасе бегут в замок! Защищайте их!"};
   private readonly string[] _thirdSceneENPhrases =  {"The civilians are running to the castle in terror! Protect them!"};
   
   //Scene 4
   private readonly string[] _fourthSceneRUPhrases =  {"Твои жалкие попытки спасти эти земли ничего не решат, ваш конец уже близок!"};
   private readonly string[] _fourthSceneENPhrases =  {"Your pathetic attempts to save these lands will not solve anything, your end is already near!"};
   
   //Scene 5
   private readonly string[] _fifthSceneRUPhrases =  {"Уничтожте остатки ненавистных енотов, эта земля с роду принадлежала котам-самураям!"};
   private readonly string[] _fifthSceneENPhrases =  {"Destroy the remnants of the hated raccoons, this land has always belonged to the samurai cats!"};
   
   //Scene 6
   private readonly string[] _sixthSceneRUPhrases =  {"Мы хорошо постарались, генерал, дома нас ждут первоклассные суши"};
   private readonly string[] _sixthSceneENPhrases =  {"We did a good job, General, we have some first-class sushi waiting for us at home."};
   
   //Scene 7
   private readonly string[] _seventhSceneRUPhrases =  {"Вам повезло, что вы остались в живых. Один из ваших самураев тащил вас через бамбуковые заросли более часа, он заслужил хорошие суши."};
   private readonly string[] _seventhSceneENPhrases =  {"You're lucky to be alive. One of your samurai dragged you through the bamboo for over an hour, he deserves some good sushi."};
   
   //Scene 8
   private readonly string[] _eighthSceneRUPhrases =  {"Еще вчера мы бы просто ограбили тебя и оставили умирать, но сегодня мы готовы присоедениться, за добротную порцию суши."};
   private readonly string[] _eighthSceneENPhrases =  {"Yesterday we would have simply robbed you and left you for dead, but today we are ready to join in, for a good portion of sushi."};
   
   //Scene 9
   private readonly string[] _nineSceneRUPhrases =  {"Наши войны восстановили силы, пора выбираться отсюда"};
   private readonly string[] _nineSceneENPhrases =  {"Our warriors have regained their strength, it's time to get out of here"};
   
   //Scene 10
   private readonly string[] _tenSceneRUPhrases =  {"Генерал, все соседние поселения в огне. Мы должны схватить одного из енотов и допросить."};
   private readonly string[] _tenSceneENPhrases =  {"General, all the neighboring settlements are on fire. We must capture one of the raccoons and interrogate him."};

   #endregion

   private void Awake()
   {
      Instance = this;
      
      _currentSceneIndex = SceneContext.Instance.GetSceneIndex();

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
               if (YG2.envir.language == "ru")
               {
                  _storyText.text = _firstSceneRUPhrases[_dialogIndex];
               }
               else
               {
                  _storyText.text = _firstSceneENPhrases[_dialogIndex];
               }
               _dialogIndex++;
               break;
            case 3:
               if (YG2.envir.language == "ru")
               {
                  _storyText.text = _secondSceneRUPhrases[_dialogIndex];
               }
               else
               {
                  _storyText.text = _secondSceneENPhrases[_dialogIndex];
               }
               _dialogIndex++;
               break;
            case 4:
               if (YG2.envir.language == "ru")
               {
                  _storyText.text = _thirdSceneRUPhrases[_dialogIndex];
               }
               else
               {
                  _storyText.text = _thirdSceneENPhrases[_dialogIndex];
               }
               _dialogIndex++;
               break;
            case 5:
               if (YG2.envir.language == "ru")
               {
                  _storyText.text = _fourthSceneRUPhrases[_dialogIndex];
               }
               else
               {
                  _storyText.text = _fourthSceneENPhrases[_dialogIndex];
               }
               _dialogIndex++;
               break;
            case 6:
               if (YG2.envir.language == "ru")
               {
                  _storyText.text = _fifthSceneRUPhrases[_dialogIndex];
                  
               }
               else
               {
                  _storyText.text = _fifthSceneENPhrases[_dialogIndex];
               }
               
               _dialogIndex++;
               break;
            case 7:
               if (YG2.envir.language == "ru")
               {
                  _storyText.text = _sixthSceneRUPhrases[_dialogIndex];
               }
               else
               {
                  _storyText.text = _sixthSceneENPhrases[_dialogIndex];
               }
               _dialogIndex++;
               break;
            case 8:
               if (YG2.envir.language == "ru")
               {
                  _storyText.text = _seventhSceneRUPhrases[_dialogIndex];
               }
               else
               {
                  _storyText.text = _seventhSceneENPhrases[_dialogIndex];
               }
               _dialogIndex++;
               break;
            case 9:
               if (YG2.envir.language == "ru")
               {
                  _storyText.text = _eighthSceneRUPhrases[_dialogIndex];
               }
               else
               {
                  _storyText.text = _eighthSceneENPhrases[_dialogIndex];
               }
               _dialogIndex++;
               break;
            case 10:
               if (YG2.envir.language == "ru")
               {
                  _storyText.text = _nineSceneRUPhrases[_dialogIndex];
               }
               else
               {
                  _storyText.text = _nineSceneENPhrases[_dialogIndex];
               }
               _dialogIndex++;
               break;
            case 11:
               if (YG2.envir.language == "ru")
               {
                  _storyText.text = _tenSceneRUPhrases[_dialogIndex];
               }
               else
               {
                  _storyText.text = _tenSceneENPhrases[_dialogIndex];
               }
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
