using UnityEngine;
using UnityEngine.EventSystems;

public class CancelRemoveCatAction : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (RemoveCatHandler.Instance.IsRemoveCatMode)
        {
            RemoveCatHandler.Instance.RemoveCatModeOff();
        }

    }
}
