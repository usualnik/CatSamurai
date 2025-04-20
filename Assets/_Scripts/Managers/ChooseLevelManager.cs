using UnityEngine;

public class ChooseLevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _levelsPages;
    private int _currentPage;

    public void NextPage()
    {
        if (_currentPage < _levelsPages.Length - 1)
        {
            _levelsPages[_currentPage].gameObject.SetActive(false);
            _currentPage++;
            _levelsPages[_currentPage].gameObject.SetActive(true);
        }
        
    }
}
