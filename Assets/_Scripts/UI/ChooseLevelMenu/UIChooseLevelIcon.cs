using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIChooseLevelIcon : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _levelIndex;
    [SerializeField] private GameObject _loadingScreen;
    public event EventHandler<UIChooseLevelIconEventArgs> OnClick;

    public class UIChooseLevelIconEventArgs : EventArgs
    {
        public int Index;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (UISound.Instance != null)
        {
            UISound.Instance.PlayUISound();
        }
        
        _loadingScreen.SetActive(true);
        
        OnClick?.Invoke(this, new UIChooseLevelIconEventArgs(){Index = _levelIndex});
    }

    public int GetLevelIndex()
    {
        return _levelIndex;
    }
}
