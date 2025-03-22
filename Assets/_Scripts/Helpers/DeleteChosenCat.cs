using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteChosenCat : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (UIChooseCatMenu.Instance.CurrentChosenCat)
        {
            UIChooseCatMenu.Instance.DeleteCurrentCat();
        }
       
    }
}
