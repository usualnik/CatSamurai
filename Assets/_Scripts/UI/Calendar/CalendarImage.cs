using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class CalendarImage : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _giveSashimiAnim;
   
    private enum GiftType
    {
        Sashimi,
        Chest
    }

    [SerializeField] private GiftType _giftType;

    [SerializeField] private int _sashimiValue;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (SFX.Instance != null)
        {
            SFX.Instance.PlayLevelUpSound();
        }
        
        GiveGift();
        
        gameObject.SetActive(false);
        
    }

    private void GiveGift()
    {
        switch (_giftType)
        {
            case GiftType.Sashimi:
                GiveSashimi();
                break;
            case GiftType.Chest:
                GiveChest();
                break;
        }
    }

    private void GiveSashimi()
    {
        Instantiate(_giveSashimiAnim, transform.position, quaternion.identity, transform.parent);
        SaveLoad.Instance.SaveSashimiValue(_sashimiValue);
        //Start 24 hours cooldown
    }
    private void GiveChest()
    {
        //Show chest animation and give player random item from chest
    }
    
}
