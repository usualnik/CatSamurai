using UnityEngine;

public class LoadCompletedScenes : MonoBehaviour
{
    [SerializeField] private UIChooseLevelIcon[] _levels;
   
    void Start()
    {
        ShowCompletedLevels();
    }

    private void ShowCompletedLevels()
    {
        foreach (var level in _levels)
        {
            if (level.GetLevelIndex() <= SaveLoad.Instance.GetCompletedLevelIndex())
            {
                level.gameObject.SetActive(true);
            }
            else
            {
                break;
            }
        }
    }

}
