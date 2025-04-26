using UnityEngine;
using UnityEngine.EventSystems;

public class CalendarImage : MonoBehaviour, IPointerClickHandler
{
    
    
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (SFX.Instance != null)
        {
            SFX.Instance.PlayLevelUpSound();
        }
        gameObject.SetActive(false);
    }
}
