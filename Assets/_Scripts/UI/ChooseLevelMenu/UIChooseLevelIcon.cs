using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIChooseLevelIcon : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _iconIndex;
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
        
        OnClick?.Invoke(this, new UIChooseLevelIconEventArgs(){Index = _iconIndex});
    }
}
