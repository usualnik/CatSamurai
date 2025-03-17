using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class GridCell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public bool ThisGridCellIsAvailable { get; private set; } = true;
    public event EventHandler OnCatPlaced;
 

    private UIChooseCatMenu _uiChooseCatMenu;

    private void Start()
    {
        _uiChooseCatMenu = GameObject.Find("UI_ChooseCatMenu").GetComponent<UIChooseCatMenu>();
        
    }

    public void OnPointerEnter(PointerEventData eventData) // Just a visual representation
     {
         if (_uiChooseCatMenu.CurrentChosenCat != null)
         {
             _uiChooseCatMenu.CurrentChosenCat.transform.SetParent(gameObject.transform);
             _uiChooseCatMenu.CurrentChosenCat.transform.position = transform.position;
         }
     }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_uiChooseCatMenu.CurrentChosenCat != null && ThisGridCellIsAvailable)
        {
            GameManager.Instance.SubtractSushi(_uiChooseCatMenu.CurrentChosenCat.GetComponent<BaseCat>().CatDataSo.CatPrice);
            
            OnCatPlaced?.Invoke(this, EventArgs.Empty);
            
            ThisGridCellIsAvailable = false;
            GridManager.Instance.ShowGridUpdated();
            
        }
        
    }
}
