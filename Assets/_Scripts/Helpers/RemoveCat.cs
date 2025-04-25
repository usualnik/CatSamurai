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
        SushiManager.Instance.AddSushi(catInfo.CatDataSo.CatPrice / 2);
        RemoveCatHandler.Instance.RemoveCat(catInfo.GetGridCell(), catInfo);
    }
}
