using UnityEngine;
using YG;

namespace YG
{
    public partial class SavesYG
    {
        public int levelsCompleted; 
    }
}

namespace YG
{
    public partial class SavesYG 
    {
        public int sashimi; // In-app store coins
    }
}

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("MORE THAN ONE INSTANCE OF SAVELOAD");
        }
        
    }

    public void SaveCompletedLevelIndex(int levelIndex)
    {
        YG2.saves.levelsCompleted = levelIndex;
        YG2.SaveProgress();
    }

    public int GetCompletedLevelIndex()
    {
        return YG2.saves.levelsCompleted;
    }

    
    
}
