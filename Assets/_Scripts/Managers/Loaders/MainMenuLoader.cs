using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLoader : MonoBehaviour
{
   private const int SCENE_CHOOSE_SCREEN_BULID_INDEX = 1;
   
   
   public void LoadChooseScene()
   {
      SceneManager.LoadScene(SCENE_CHOOSE_SCREEN_BULID_INDEX);
   }
}
