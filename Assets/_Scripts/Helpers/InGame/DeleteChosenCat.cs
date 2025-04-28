using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteChosenCat : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (UISound.Instance != null)
        {
            UISound.Instance.PlayUISound();
        }
        
        if (UIChooseCatMenu.Instance.CurrentChosenCat)
        {
            UIChooseCatMenu.Instance.DeleteCurrentCat();
        }
       
    }
}
