using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteChosenCat : MonoBehaviour, IPointerClickHandler
{
    
    public void OnPointerClick(PointerEventData eventData)
    {
        UIChooseCatMenu.Instance.DeleteCurrentCat();
    }
}
