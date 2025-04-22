using UnityEngine;
using UnityEngine.EventSystems;

public class RemoveCat : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (UISound.Instance != null)
        {
            UISound.Instance.PlayUISound();
        }
        
        BaseCat catInfo = GetComponentInParent<BaseCat>();
        
        RemoveCatHandler.Instance.RemoveCat(catInfo.GetGridCell(), catInfo);
    }
}
